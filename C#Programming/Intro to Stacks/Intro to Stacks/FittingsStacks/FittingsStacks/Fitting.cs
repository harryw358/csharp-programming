using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FittingsStacks
{
    public class Fitting
    {
        private string _carReg, _fittingDate, _tyreType;
        private int _numOfTyres;
        private double _costOfFitting;

        public string CarReg { get => _carReg; set => _carReg = value; }
        public string FittingDate { get => _fittingDate; set => _fittingDate = value; }
        public string TyreType { get => _tyreType; set => _tyreType = value; }
        public int NumOfTyres { get => _numOfTyres; set => _numOfTyres = value; }
        public double CostOfFitting { get => _costOfFitting; set => _costOfFitting = value; }

        public Fitting(string carReg, string fittingDate, string tyreType, int numOfTyres, double costOfFitting)
        {
            _carReg = carReg;
            _fittingDate = fittingDate;
            _tyreType = tyreType;
            _numOfTyres = numOfTyres;
            _costOfFitting = costOfFitting;
        }
    }
}