using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SubOperation
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Symbol", "-")]
    public class SubOperation : IPlugin
    {
        public double Do(double _f, double _s)
        {
            return _f - _s;
        }
    }


}
