using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;

namespace SubOperation
{
    public class SubOperation : IPlugin
    {
        public string Name
        {
            get { return "-"; }
        }

        public double Do(double _f, double _s)
        {
            return _f - _s;
        }
    }
}
