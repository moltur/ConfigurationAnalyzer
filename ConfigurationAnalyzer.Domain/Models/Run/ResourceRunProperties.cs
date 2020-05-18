namespace ConfigurationAnalyzer.Domain.Models
{
	public class ResourceRunProperties
	{
		public Resource Resource { get; set; }

		public double InUseTime { get; set; }

		public double InefficiencyTime { get; set; }
	}
}
