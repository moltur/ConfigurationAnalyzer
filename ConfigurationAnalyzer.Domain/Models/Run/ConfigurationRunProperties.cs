using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Models
{
	public class ConfigurationRunProperties
	{
		public int Id { get; set; }

		public Configuration Configuration { get; set; }

		public int Duration { get; set; }

		public decimal Cost { get; set; }

		public int InefficiencyTime { get; set; }

		public IEnumerable<ProcedureRunProperties> Procedures { get; set; }

		public IEnumerable<ResourceRunProperties> Resources { get; set; }
	}
}
