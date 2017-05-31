using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PluginContracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        [ImportMany]
        private IEnumerable<Lazy<IPlugin, IPluginData>> plugins;

        private CompositionContainer _container;
        private ViewModel _vm = new ViewModel();
        private IPlugin _current = null;

        void load()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog("plugins"));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            load();
            foreach(var item in plugins)
            {
                Button b = new Button();
                b.Content = item.Metadata.Symbol;
                b.Click += b_Click;
                PluginGrid.Children.Add(b);
            }
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if(b != null)
            {
                string key = b.Content.ToString();
                foreach(var p in plugins)
                {
                    if(p.Metadata.Symbol == key)
                    {
                        _current = p.Value;
                        UIOperator = p.Metadata.Symbol;
                        break;
                    }
                }
            }
        }

        public double UIFirst
        {
            get { return _vm.First; }
            set { 
                _vm.First = value;
                NotifyPropertyChanged("UIFirst");
            }
        }

        public double UISecond
        {
            get { return _vm.Second; }
            set 
            { 
                _vm.Second = value;
                NotifyPropertyChanged("UISecond");
            }
        }

        public double UIResult 
        {
            get { return _vm.Result; }
            set
            {
                _vm.Result = value;
                NotifyPropertyChanged("UIResult");
            }
        }
        
        public string UIOperator
        {
            get { return _vm.Operator; }
            set { _vm.Operator = value; NotifyPropertyChanged("UIOperator"); }
        }

        private void GetResult(object sender, RoutedEventArgs e)
        {
            if(_current != null)
            {
                UIResult = _current.Do(UIFirst, UISecond);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName= null)
        {
            if(!EqualityComparer<T>.Default.Equals(item, value))
            {
                item = value;
                NotifyPropertyChanged(propertyName);
            }
        }
    }
}
