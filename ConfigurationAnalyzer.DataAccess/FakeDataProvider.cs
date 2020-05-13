using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess
{
	public class FakeDataProvider: IDataProvider<long, ConfigurationRunProperties>
	{
		public IDictionary<long, IEnumerable<ConfigurationRunProperties>> GetData()
		{
			return new Dictionary<long, IEnumerable<ConfigurationRunProperties>>();
		}
	}
}
