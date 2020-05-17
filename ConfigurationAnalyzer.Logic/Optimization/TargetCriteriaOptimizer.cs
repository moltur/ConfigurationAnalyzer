using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class TargetCriteriaOptimizer : IBestConfigurationCalculator
	{
		private Criteria TargetCriteria { get; set; } 

		private readonly IConverter<ConfigurationRunPropertiesProcessed, Criteria> _converter;

		private readonly ICriteriaProcessor _criteriaProcessor;

		public TargetCriteriaOptimizer(IConverter<ConfigurationRunPropertiesProcessed, Criteria> converter, ICriteriaProcessor criteriaProcessor)
		{
			TargetCriteria = new Criteria();
			_converter = converter;
			_criteriaProcessor = criteriaProcessor;
		}

		public IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items)
		{
			var bestDistance = double.MaxValue;
			var results = new List<int>();

			var criteriaArr = _criteriaProcessor.Normalize(items.Select(_converter.Convert));

			TargetCriteria = _criteriaProcessor.FindMinValuesPerCriteria(criteriaArr);

			foreach (var criteria in criteriaArr)
			{
				var distance = TargetCriteria.GetDistance(criteria);
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
