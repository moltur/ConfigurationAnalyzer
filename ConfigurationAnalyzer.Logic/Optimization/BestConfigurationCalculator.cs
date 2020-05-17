using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class BestConfigurationCalculator : IBestConfigurationCalculator
	{
		private readonly IConcessionOptimizer _concessionOptimizer;
		private readonly ITargetCriteriaOptimizer _targetCriteriaOptimizer;

		public BestConfigurationCalculator(IConcessionOptimizer concessionOptimizer, ITargetCriteriaOptimizer targetCriteriaOptimizer)
		{
			_concessionOptimizer = concessionOptimizer;
			_targetCriteriaOptimizer = targetCriteriaOptimizer;
		}

		public IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items, int method)
		{
			switch (method)
			{
				case 0:
					{
						return _targetCriteriaOptimizer.Calculate(items);
					}
				case 1:
					{
						return _concessionOptimizer.Calculate(items);
					}
				default:
					{
						return new List<int>();
					}
			}
		}
	}
}
