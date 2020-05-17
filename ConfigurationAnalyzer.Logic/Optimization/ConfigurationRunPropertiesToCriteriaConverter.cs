using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class ConfigurationRunPropertiesToCriteriaConverter : IConverter<ConfigurationRunPropertiesProcessed, Criteria>
	{
		public Criteria Convert(ConfigurationRunPropertiesProcessed item)
		{
			return new Criteria
			{
				ConfigurationId = item.Configuration.Id,
				Duration = item.Duration,
				DurationBest = item.DurationBest,
				DurationWorst = item.DurationWorst,
				InefficiencyTime = item.InefficiencyTime,
				InefficiencyTimeBest = item.InefficiencyTimeBest,
				InefficiencyTimeWorst = item.InefficiencyTimeWorst,
				Cost = item.Cost
			};
		}
	}
}
