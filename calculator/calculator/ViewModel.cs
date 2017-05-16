using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class ViewModel
    {
        public ViewModel()
        {

        }

        public DataModel _dm = new DataModel(0, "+", 0);

        public double First
        {
            get { return _dm.FirstNumber; }
            set { _dm.FirstNumber = value; }
        }

        public double Second
        {
            get { return _dm.SecondNumber; }
            set { _dm.SecondNumber = value; }
        }

        public double Result
        {
            get { return _dm.Result; }
            set { _dm.Result = value; }
        }

        public string Operator
        {
            get { return _dm.Operation; }
            set { _dm.Operation = value; }
        }
    }
}
