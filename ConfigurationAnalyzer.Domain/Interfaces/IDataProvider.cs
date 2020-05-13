using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IDataProvider<TId, TElement> 
		where TId : struct 
		where TElement : class
	{
		IDictionary<TId, IEnumerable<TElement>> GetData();
	}
}
