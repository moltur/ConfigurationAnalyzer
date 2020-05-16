using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class TargetCriteriaOptimizer : IBestConfigurationCalculator
	{
		private readonly Criteria _targetCriteria = new Criteria();

		private readonly IConverter<ConfigurationRunPropertiesProcessed, Criteria> _converter;

		public TargetCriteriaOptimizer(IConverter<ConfigurationRunPropertiesProcessed, Criteria> converter)
		{
			_converter = converter;
		}

		public IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items)
		{
			var bestDistance = double.MaxValue;
			var results = new List<int>();

			var criteriaArr = items.Select(_converter.Convert);

			foreach (var criteria in criteriaArr)
			{
				var distance = _targetCriteria.GetDistance(criteria);
				if (distance == bestDistance)
				{
					results.Add(criteria.ConfigurationId);
				} 
				else if (distance < bestDistance)
				{
					results = new List<int>
					{
						criteria.ConfigurationId
					};
				}
			}

			return results;
		}

	}
}
