namespace ConfigurationAnalyzer.Logic.Optimization.Interfaces
{
	public interface IConverter<TIn, TOut>
	{
		TOut Convert(TIn item);
	}
}
