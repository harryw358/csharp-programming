using System;
using System.Collections.Generic;
using System.Text;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.Backend
{
    public class Account
    {
        private int _accountID;
        private int _level;
        private double _xp;
        private int _wins;
        private int _roundsPlayed;
        private string _username;
        private string _password;
        private int _eliminations;
        private int _deaths;
        private int _coins;
        private List<string> _availableUpgrades;

        public int AccountID { get => _accountID; set => _accountID = value; }
        public int Level { get => _level; set => _level = value; }
        public double XP { get => _xp; set => _xp = value; }
        public int Wins { get => _wins; set => _wins = value; }
        public int RoundsPlayed { get => _roundsPlayed; set => _roundsPlayed = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int Eliminations { get => _eliminations; set => _eliminations = value; }
        public int Deaths { get => _deaths; set => _deaths = value; }
        public int Coins { get => _coins; set => _coins = value; }
        public List<string> AvailableUpgrades { get => _availableUpgrades; set => _availableUpgrades = value; }

        public Account(int accountID, int level, double xp, int wins, int roundsPlayed, string username, string password, int elimations, int deaths, int coins)
        {
            _accountID = accountID;
            _level = level;
            _xp = xp;
            _wins = wins;
            _roundsPlayed = roundsPlayed;
            _username = username;
            _password = password;
            _eliminations = elimations;
            _deaths = deaths;
            _coins = coins;
            _availableUpgrades = new List<string>();
        }

        public void UpdateScores()
        {
            var database = new Database();
            database.UpdateAccount(this);
        }
    }
}
