using System;
namespace PluginContracts
{
	public interface IPlugin
	{
		double Do(double _f, double _s);
	}

    public interface IPluginData
    {
        string Symbol { get; }
    }

}
