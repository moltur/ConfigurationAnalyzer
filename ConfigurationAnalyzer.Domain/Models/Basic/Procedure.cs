using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Models
{
	public class Procedure
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<Resource> Resources { get; set; }
	}
}
