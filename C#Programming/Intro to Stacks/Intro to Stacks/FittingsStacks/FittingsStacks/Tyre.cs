using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FittingsStacks
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
        }
    }
}
