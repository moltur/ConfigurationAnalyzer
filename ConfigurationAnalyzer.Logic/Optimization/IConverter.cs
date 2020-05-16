namespace ConfigurationAnalyzer.Logic.Optimization
{
	public interface IConverter<TIn, TOut>
	{
		TOut Convert(TIn item);
	}
}
