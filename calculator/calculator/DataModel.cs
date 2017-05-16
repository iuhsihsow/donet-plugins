using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class DataModel
    {
        public DataModel(double _first, string _oper, double _second)
        {
            _n1 = _first;
            _o = _oper;
            _n2 = _second;
        }

        public double Add()
        {
            return _n1 + _n2;
        }

        public double FirstNumber {
            get { return _n1; }
            set { _n1 = value; }
        }
        public double SecondNumber 
        {
            get { return _n2; }
            set { _n2 = value; }
        }

        public string Operation
        {
            get { return _o; }
            set { _o = value; }
        }

        public double Result
        {
            get { return _r; }
            set { _r = value; }
        }

        private double _n1;
        private double _n2;
        private double _r;
        private string _o;
    }
}
