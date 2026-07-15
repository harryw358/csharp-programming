using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Exercise4
{
    public class Tyre
    {
        private string _type;
        private int _stockLeft;
        private double _price;

        public string Type { get => _type; set => _type = value; }
        public int StockLeft { get => _stockLeft; set => _stockLeft = value; }
        public double Price { get => _price; set => _price = value; }

        public Tyre(string type, int stockLeft, double price)
        {
            _type = type;
            _stockLeft = stockLeft;
            _price = price;
        }
        public void AddNewStock(int newStock)
        {
            _stockLeft += newStock;

            // updates values in database
            ChangeStock(_stockLeft);

        }
        public void RemoveStock(int stockToRemove)
        {
            _stockLeft -= stockToRemove;

            // update values in database
            ChangeStock(_stockLeft);
        }
        public void CreateNewType()
        {
            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TyresDatabase.mdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand command = new OleDbCommand("INSERT into TyreStockDb (Type,StockLeft,Price) values('" + _type + "','" + _stockLeft + "','" + _price + "')", conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("The new type has been recorded.");
            return;
        }
        private void ChangeStock(int newStock)
        {
            var connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TyresDatabase.mdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            OleDbCommand command = new OleDbCommand("UPDATE TyreStockDb SET StockLeft= " + newStock + " WHERE Type=" + "'" + _type + "'" + "", conn);
            try
            {
              command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            return;
        }
    }
}
