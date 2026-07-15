using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SQLite;
using System.Security.Principal;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.Backend
{
    public class Database
    {
        private const string PATH = "data.db";

        private SQLiteCommand _command;
        private SQLiteDataReader _dataReader;
        private List<Account> _records;

        public Database()
        {
            CreateDatabase();
            _records = new List<Account>();
            _records = FillList();
        }

        public void CreateDatabase()
        { 
            if (!File.Exists(PATH))
            {
                try
                {
                    SQLiteConnection.CreateFile(PATH);
                    using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                    {
                        string cmdText;
                        connection.Open();

                        // Accounts table
                        cmdText = @"CREATE TABLE ""Accounts"" (
	""AccountID""	INTEGER NOT NULL UNIQUE,
	""Level""	INTEGER,
	""XP""	NUMERIC,
	""Wins""	INTEGER,
	""RoundsPlayed""	INTEGER,
	""Username""	TEXT UNIQUE,
	""Password""	TEXT,
	""Eliminations""	INTEGER,
	""Deaths""	INTEGER,
	""Coins""	INTEGER,
	PRIMARY KEY(""AccountID"" AUTOINCREMENT)
);";
                        _command = new SQLiteCommand(cmdText, connection);
                        _command.ExecuteNonQuery();

                        // Upgrades table
                        cmdText = @"CREATE TABLE ""Upgrades"" (
	""UpgradeID""	INTEGER NOT NULL UNIQUE,
	""Name""	TEXT UNIQUE,
	""Description""	TEXT,
	""Cost""	INTEGER,
	""Class""	TEXT,
	PRIMARY KEY(""UpgradeID"" AUTOINCREMENT)
);";
                        _command = new SQLiteCommand(cmdText, connection);
                        _command.ExecuteNonQuery();
                        InitialiseUpgradesTable(connection);

                        // AccountUpgrades table
                        cmdText = @"CREATE TABLE ""AccountUpgrades"" (
	""AccountUpgradeID""	INTEGER NOT NULL UNIQUE,
	""AccountID""	INTEGER NOT NULL,
	""UpgradeID""	INTEGER NOT NULL,
	FOREIGN KEY(""AccountID"") REFERENCES ""Accounts""(""AccountID""),
	FOREIGN KEY(""UpgradeID"") REFERENCES ""Upgrades""(""UpgradeID""),
	PRIMARY KEY(""AccountUpgradeID"" AUTOINCREMENT)
);";
                        _command = new SQLiteCommand(cmdText, connection);
                        _command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Could not create new table.");
                }
            }
            else
            {
                return;
            }
        }

        public void InsertNewAccount(Account account)
        {
            // intialises new account and insert into database

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    int LEVEL = account.Level;
                    double XP = account.XP;
                    int WINS = account.Wins;
                    int ROUNDSPLAYED = account.RoundsPlayed;
                    string USERNAME = account.Username;
                    string PASSWORD = Hash(account.Password);
                    int ELIMINATIONS = account.Eliminations;
                    int DEATHS = account.Deaths;
                    int COINS = account.Coins;

                    _command = new SQLiteCommand(connection);
                    _command.CommandText = @"INSERT INTO Accounts(
Level, XP, Wins, RoundsPlayed, Username, Password, Eliminations, Deaths, Coins)
VALUES(@LEVEL, @XP, @WINS, @ROUNDSPLAYED, @USERNAME, @PASSWORD, @ELIMINATIONS, @DEATHS, @COINS)";

                    _command.Parameters.AddWithValue("@LEVEL", LEVEL);
                    _command.Parameters.AddWithValue("@XP", XP);
                    _command.Parameters.AddWithValue("@WINS", WINS);
                    _command.Parameters.AddWithValue("@ROUNDSPLAYED", ROUNDSPLAYED);
                    _command.Parameters.AddWithValue("@USERNAME", USERNAME);
                    _command.Parameters.AddWithValue("@PASSWORD", PASSWORD);
                    _command.Parameters.AddWithValue("@ELIMINATIONS", ELIMINATIONS);
                    _command.Parameters.AddWithValue("@DEATHS", DEATHS);
                    _command.Parameters.AddWithValue("@COINS", COINS);

                    _command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Could not insert new account");
            }
        }

        public List<Account> FillList()
        {
            List<Account> records = new List<Account>();

            try
            {
                // create new connetion to database
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);
                    _command.CommandText = "SELECT * FROM Accounts";
                    _dataReader = _command.ExecuteReader();

                    while (_dataReader.Read())
                    {
                        int accountID = _dataReader.GetInt32(0);
                        int level = _dataReader.GetInt32(1);
                        double xp = _dataReader.GetDouble(2);
                        int wins = _dataReader.GetInt32(3);
                        int roundsPlayed = _dataReader.GetInt32(4);
                        string username = _dataReader.GetString(5);
                        string password = _dataReader.GetString(6);
                        int eliminations = _dataReader.GetInt32(7);
                        int deaths = _dataReader.GetInt32(8);
                        int coins = _dataReader.GetInt32(9);

                        var account = new Account(accountID, level, xp, wins, roundsPlayed, username, password, eliminations, deaths, coins);
                        records.Add(account);
                    }

                    connection.Close();
                }
            }
            catch
            {
                throw new Exception("Could not fill records.");
            }

            return records;
        }

        private bool CheckForExistingRecord(int accountID)
        {
            for (int currentRecord = 0; currentRecord < _records.Count; currentRecord++)
            {
                if (_records[currentRecord].AccountID == accountID)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateAccount(Account account)
        {
            // find account using account ID and update statistics

            try
            {
                if (CheckForExistingRecord(account.AccountID))
                {
                    using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                    {
                        connection.Open();

                        int LEVEL = account.Level;
                        double XP = account.XP;
                        int WINS = account.Wins;
                        int ROUNDSPLAYED = account.RoundsPlayed;
                        int ELIMINATIONS = account.Eliminations;
                        int DEATHS = account.Deaths;
                        int COINS = account.Coins;

                        if (XP >= 1000)
                        {
                            LEVEL++;
                            double leftoverXP = 1000 - XP;
                            XP = leftoverXP;
                        }

                        _command = new SQLiteCommand(connection);

                            _command.CommandText = @"UPDATE Accounts
    SET Level=@LEVEL, XP=@XP, Wins=@WINS, RoundsPlayed=@ROUNDSPLAYED, Eliminations=@ELIMINATIONS, Deaths=@DEATHS, Coins=@COINS
    WHERE AccountID=@ACCOUNTID";
                        _command.Parameters.AddWithValue("@LEVEL", LEVEL);
                        _command.Parameters.AddWithValue("@XP", XP);
                        _command.Parameters.AddWithValue("@WINS", WINS);
                        _command.Parameters.AddWithValue("@ROUNDSPLAYED", ROUNDSPLAYED);
                        _command.Parameters.AddWithValue("@ELIMINATIONS", ELIMINATIONS);
                        _command.Parameters.AddWithValue("@DEATHS", DEATHS);
                        _command.Parameters.AddWithValue("@COINS", COINS);
                        _command.Parameters.AddWithValue("@ACCOUNTID", account.AccountID);

                        _command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                else
                {
                    InsertNewAccount(account);
                }
            }
            catch
            {
                throw new Exception("Could not update accounts table.");
            }
        }

        public Account FetchAccount(string username)
        {
            for (int currentRecord = 0; currentRecord < _records.Count; currentRecord++)
            {
                if (_records[currentRecord].Username == username)
                {
                    int accountID = _records[currentRecord].AccountID;
                    int level = _records[currentRecord].Level;
                    double xp = _records[currentRecord].XP;
                    int wins = _records[currentRecord].Wins;
                    int roundsPlayed = _records[currentRecord].RoundsPlayed;
                    string password = _records[currentRecord].Password;
                    int eliminations = _records[currentRecord].Eliminations;
                    int deaths = _records[currentRecord].Deaths;
                    int coins = _records[currentRecord].Coins;

                    return new Account(accountID, level, xp, wins, roundsPlayed, username, password, eliminations, deaths, coins);
                }
            }

            return null;
        }

        public void AddUpgrade(Account account, string upgradeName)
        {
            // open connection to database

            int accountID = GetAccountID(account);
            int upgradeID = GetUpgradeID(upgradeName);

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);

                    _command.CommandText = "INSERT INTO AccountUpgrades(AccountID, UpgradeID) VALUES(@ACCOUNTID, @UPGRADEID)";
                    _command.Parameters.AddWithValue("@ACCOUNTID", accountID);
                    _command.Parameters.AddWithValue("UPGRADEID", upgradeID);

                    _command.ExecuteNonQuery();

                    _command.CommandText = "UPDATE Accounts SET Coins=@COINS WHERE AccountID=@ACCOUNTID";
                    _command.Parameters.AddWithValue("@COINS", account.Coins);
                    _command.Parameters.AddWithValue("@ACCOUNTID", accountID);

                    _command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
            {
                throw new Exception("Could not update AccountUpdgrades table.");
            }
        }

        public void DeleteUpgrade(Account account, string upgradeName)
        {
            // open connection to database

            int accountID = GetAccountID(account);
            int upgradeID = GetUpgradeID(upgradeName);

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);

                    _command.CommandText = @"
DELETE FROM AccountUpgrades
WHERE AccountID = " + accountID + " AND" +
" UpgradeID = " + upgradeID;

                    _command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
            {
                throw new Exception("Could not update AccountUpgrades table.");
            }
        }

        public bool AccountOwnsUpgrade(Account account, string upgradeName)
        {
            AddAvailableUpgrades(account);

            for (int i = 0; i < account.AvailableUpgrades.Count; i++)
            {
                if (account.AvailableUpgrades[i] == upgradeName)
                {
                    account.AvailableUpgrades.RemoveAt(i);
                    DeleteUpgrade(account, upgradeName);
                    return true;
                }
            }

            return false;
        }

        public void AddAvailableUpgrades(Account account)
        {
            int accountID = GetAccountID(account);

            try
            {
                // create new connection to database
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);
                    _command.CommandText = @"
SELECT UpgradeID
FROM AccountUpgrades
WHERE AccountUpgrades.AccountID = " + accountID + ";";

                    _dataReader = _command.ExecuteReader();

                    while (_dataReader.Read())
                    {
                        int upgradeID = _dataReader.GetInt32(0);
                        string upgradeName = "";

                        if (upgradeID == 1)
                        {
                            upgradeName = "charge";
                        }
                        else if (upgradeID == 2)
                        {
                            upgradeName = "lockdown";
                        }
                        else if (upgradeID == 3)
                        {
                            upgradeName = "enchantment";
                        }
                        else if (upgradeID == 4)
                        {
                            upgradeName = "stealth";
                        }
                        else if (upgradeID == 5)
                        {
                            upgradeName = "multishot";
                        }
                        else if (upgradeID == 6)
                        {
                            upgradeName = "bleed";
                        }
                        account.AvailableUpgrades.Add(upgradeName);
                    }
                }
            }
            catch
            {
                throw new Exception("Could not retrieve data from table.");
            }
        }

        private int GetAccountID(Account account)
        {
            int accountID = 0;

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);
                    _command.CommandText = "SELECT AccountID FROM Accounts WHERE Username='" + account.Username + "'";
                    _dataReader = _command.ExecuteReader();

                    while (_dataReader.Read())
                    {
                        accountID = _dataReader.GetInt32(0);
                    }

                    _dataReader.Close();

                    connection.Close();
                }
            }
            catch
            {
                throw new Exception("Could not retrieve field from database table.");

            }

            return accountID;
        }

        private int GetUpgradeID(string upgradeName)
        {
            int databaseUpgradeID = 0;

            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=" + PATH))
                {
                    connection.Open();

                    _command = new SQLiteCommand(connection);
                    _command.CommandText = "SELECT UpgradeID FROM Upgrades WHERE Name='" + upgradeName + "'";
                    _dataReader = _command.ExecuteReader();

                    while (_dataReader.Read())
                    {
                        databaseUpgradeID = _dataReader.GetInt32(0);
                    }

                    connection.Close();
                }
            }
            catch
            {
                throw new Exception("Could not retrieve field from database table.");
            }

            return databaseUpgradeID;
        }

        private string Hash(string source)
        {
            // convert the source string into an array of bytes
            byte[] value = ASCIIEncoding.ASCII.GetBytes(source);
            // hash the byte array and return as a hexadecimal string
            return Convert.ToHexString(SHA256.Create().ComputeHash(value));
        }

        private void InitialiseUpgradesTable(SQLiteConnection connection)
        {
            try
            {
                string cmdText;

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('charge', 'launch an attack and knockback your opponent', 100, 'melee')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('lockdown', 'reduce damage taken by 30%', 200, 'melee')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('enchantment', 'deal 200% damage to opponent', 100, 'mage')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('stealth', 'move quickly and pass through opponent', 200, 'mage')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('multishot', 'fire 3 projectiles at once in a quick succession', 100, 'ranger')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

                cmdText = @"INSERT INTO Upgrades(
Name, Description, Cost, Class)
VALUES('bleed', 'cause damage to opponent over time after hitting them', 200, 'ranger')";
                _command = new SQLiteCommand(cmdText, connection);
                _command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw new Exception("Could not insert data into table.");
            }
        }
    }
}

