namespace PluginContracts
{
	public interface IPlugin
	{
		string Name { get; }
        string ShowSymbol { get; }
		double Do(double _f, double _s);
	}
}
