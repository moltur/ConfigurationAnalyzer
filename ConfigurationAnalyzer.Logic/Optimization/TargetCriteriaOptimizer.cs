using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class TargetCriteriaOptimizer : IBestConfigurationCalculator
	{
		private readonly Criteria _targetCriteria = new Criteria();

		private readonly IConverter<ConfigurationRunPropertiesProcessed, Criteria> _converter;

		private readonly ICriteriaNormalizer _normalizer;

		public TargetCriteriaOptimizer(IConverter<ConfigurationRunPropertiesProcessed, Criteria> converter, ICriteriaNormalizer normalizer)
		{
			_converter = converter;
			_normalizer = normalizer;
		}

		public IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items)
		{
			var bestDistance = double.MaxValue;
			var results = new List<int>();

			var criteriaArr = _normalizer.Normalize(items.Select(_converter.Convert));


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
