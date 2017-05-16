using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {

        }

        public DataModel _dm = new DataModel(0, "+", 0);

        public double First
        {
            get { return _dm.FirstNumber; }
            set { _dm.FirstNumber = value; NotifyPropertyChanged("First"); }
        }

        public double Second
        {
            get { return _dm.SecondNumber; }
            set { _dm.SecondNumber = value; NotifyPropertyChanged("Second"); }
        }

        public double Result 
        {
            get { return _dm.Result; }
            set { _dm.Result = value; NotifyPropertyChanged("Result"); }
        }

        public string Operator
        {
            get { return _dm.Operation; }
            set { _dm.Operation = value; NotifyPropertyChanged("Operator");}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
