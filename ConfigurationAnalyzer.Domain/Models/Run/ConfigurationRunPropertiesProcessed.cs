namespace ConfigurationAnalyzer.Domain.Models
{
	public class ConfigurationRunPropertiesProcessed: ConfigurationRunProperties
	{
		public int DurationBest { get; set; }

		public int DurationWorst { get; set; }

		public int InefficiencyTimeBest { get; set; }

		public int InefficiencyTimeWorst { get; set; }


	}
}
