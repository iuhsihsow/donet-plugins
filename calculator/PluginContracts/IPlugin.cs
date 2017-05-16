namespace PluginContracts
{
	public interface IPlugin
	{
		string Name { get; }
        string ShowSymbol { get; }
		void Do(double _f, double _s);
	}
}
