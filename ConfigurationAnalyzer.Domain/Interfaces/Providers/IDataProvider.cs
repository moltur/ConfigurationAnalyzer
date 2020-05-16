using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IDataProvider<TElement, TShortElement>
		where TElement : class
		where TShortElement : class
	{
		IEnumerable<TShortElement> GetAll();

		IEnumerable<TElement> Get(int id);
	}
}
