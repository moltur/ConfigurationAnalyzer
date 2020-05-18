namespace ConfigurationAnalyzer.Domain.Models
{
	public class ConfigurationRunPropertiesProcessed: ConfigurationRunProperties
	{
		public double DurationBest { get; set; }

		public double DurationWorst { get; set; }

		public double InefficiencyTimeBest { get; set; }

		public double InefficiencyTimeWorst { get; set; }
	}
}
