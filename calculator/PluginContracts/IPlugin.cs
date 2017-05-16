namespace PluginContracts
{
	public interface IPlugin
	{
		string Name { get; }
		double Do(double _f, double _s);
	}
}
