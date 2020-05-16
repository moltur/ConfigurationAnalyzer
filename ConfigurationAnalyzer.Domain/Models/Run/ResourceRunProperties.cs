namespace ConfigurationAnalyzer.Domain.Models
{
	public class ResourceRunProperties
	{
		public Resource Resource { get; set; }

		public int InUseTime { get; set; }

		public int InefficiencyTime { get; set; }
	}
}
