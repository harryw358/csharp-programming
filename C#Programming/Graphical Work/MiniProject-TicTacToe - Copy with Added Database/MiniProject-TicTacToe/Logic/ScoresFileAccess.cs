using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MiniProject_TicTacToe.Players;

namespace MiniProject_TicTacToe
{
    public class ScoresFileAccess
    {
        private const string FILEPATH = @"scores.txt";
        private const string TEMP_FILEPATH = @"temp_scores.txt";
        private List<Player> _scoreRecords = new List<Player>();
        public ScoresFileAccess()
        {
            
        }
        // Game is instantiated
        // 1) GetPlayerSpecificRecord if one exists for a player
        // 2) DeletePlayerSpecificRecord from the file if one exists for a player
        // 3) addPlayerSpecificRecord back to file with new, updated scores
        public void addPlayerSpecificRecord(Player player)
        {
            Player currentPlayer = new Player(null, null);
            currentPlayer.Name = player.Name;
            currentPlayer.Wins = player.Wins;
            currentPlayer.Losses = player.Losses;
            currentPlayer.Draws = player.Draws;
            _scoreRecords.Add(currentPlayer);
        }
        public void rewriteAllRecords()
        {
            try
            {
                using (StreamWriter currentFile = new StreamWriter(TEMP_FILEPATH, true))
                {
                    for (int i = 0; i < _scoreRecords.Count; i++)
                    {
                        currentFile.WriteLine(_scoreRecords[i].Name + "," + _scoreRecords[i].Wins.ToString() + "," + _scoreRecords[i].Losses.ToString() + "," + _scoreRecords[i].Draws.ToString());
                    }
                    currentFile.Close();

                    File.Delete(FILEPATH);
                    File.Move(TEMP_FILEPATH, FILEPATH);
                    File.Create(TEMP_FILEPATH);
                }
            }
            catch
            {
                throw new ApplicationException("This program did not work!");
            }
        }
        public void readAllPlayerRecords()
        {
            if (CheckFileIsNotEmpty())
            {
                string[] allRecords = File.ReadAllLines(FILEPATH);
                for (int i = 0; i < allRecords.Length; i++)
                {
                    string[] currentRecord = allRecords[i].Split(',');
                    Player p = new Player(null, null);
                    p.Name = currentRecord[0];
                    p.Wins = Convert.ToInt32(currentRecord[1]);
                    p.Losses = Convert.ToInt32(currentRecord[2]);
                    p.Draws = Convert.ToInt32(currentRecord[3]);
                    _scoreRecords.Add(p);
                }
            }
        }
        public Player GetPlayerSpecificRecord(Player player)
        {
            // this method returns a string array --> { wins, losses, draws } --> all of type string
            for(int i = 0; i < _scoreRecords.Count; i++)
            {
                // name (first field) acts as an identifier for a record
                // the problem with this is 2 people can have the same name 
                // and it will count their scores as 1

                // TODO - add unique identifer for each record

                // if name matches first field of a single record, update values for scores
                // if name doesnt match skip to next record by adding 1 to i.
                // return a new record of type Player that all contains the wins, losses and draws
                // for that player
                if(_scoreRecords[i].Name == player.Name)
                {
                    Player scoreRecord = new Player(null, null);
                    scoreRecord.Wins += Convert.ToInt32(_scoreRecords[i].Wins);
                    scoreRecord.Losses += Convert.ToInt32(_scoreRecords[i].Losses);
                    scoreRecord.Draws += Convert.ToInt32(_scoreRecords[i].Draws);
                    deleteRecord(player);
                    return scoreRecord;
                }
            }
            return null;
        }
        public bool PlayerRecordFound(Player player)
        {
            readAllPlayerRecords();
            for(int i = 0; i < _scoreRecords.Count; i++)
            {
                if(_scoreRecords[i].Name == player.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public void deleteRecord(Player player)
        {
            for(int i = 0; i < _scoreRecords.Count; i++)
            {
                if(_scoreRecords[i].Name == player.Name)
                {
                    _scoreRecords.Remove(_scoreRecords[i]);
                }
            }
        }
        public bool CheckFileIsNotEmpty()
        {
            FileInfo fileInfo = new FileInfo(FILEPATH);
            if(fileInfo.Length == 0)
            {
                return false; 
            }
            return true;
        }
    }
}
