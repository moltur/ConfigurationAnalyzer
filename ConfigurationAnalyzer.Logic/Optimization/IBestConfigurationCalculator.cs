using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public interface IBestConfigurationCalculator
	{
		IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items);
	}
}