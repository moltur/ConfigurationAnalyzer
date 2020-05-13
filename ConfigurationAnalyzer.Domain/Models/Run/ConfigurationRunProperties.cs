using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Models
{
	public class ConfigurationRunProperties
	{
		public long Id { get; set; }

		public Configuration Configuration { get; set; }

		public double Duration { get; set; }

		public double Cost { get; set; }

		public double InefficiencyTime { get; set; }

		public IDictionary<long, ProcedureRunProperties> Procedures { get; set; }

		public IDictionary<long, ResourceRunProperties> Resources { get; set; }
	}
}
