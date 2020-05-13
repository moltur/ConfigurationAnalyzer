namespace ConfigurationAnalyzer.Domain.Models
{
	public class ProcedureRunProperties
	{
		public Procedure Procedure { get; set; }

		public double Duration { get; set; }

		public double InefficiencyTime { get; set; }
	}
}
