using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization.Interfaces
{
	public interface IBestConfigurationCalculator
	{
		IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items);
	}
}