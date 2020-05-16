using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess
{
	public class FakeDataProvider
	{
		public IDictionary<int, IEnumerable<ConfigurationRunProperties>> GetData()
		{
			return new Dictionary<int, IEnumerable<ConfigurationRunProperties>>();
		}
	}
}
