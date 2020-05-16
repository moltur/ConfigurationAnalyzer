namespace ConfigurationAnalyzer.Domain.Models
{
	public class ProcedureRunProperties
	{
		public Procedure Procedure { get; set; }

		public int Duration { get; set; }

		public int InefficiencyTime { get; set; }
	}
}
