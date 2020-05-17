using System;

namespace ConfigurationAnalyzer.Logic.Optimization.Models
{
	public class Criteria
	{
		public int ConfigurationId { get; set; }

		public int Duration { get; set; }

		public int DurationBest { get; set; }

		public int DurationWorst { get; set; }

		public int InefficiencyTime { get; set; }

		public int InefficiencyTimeBest { get; set; }

		public int InefficiencyTimeWorst { get; set; }

		public decimal Cost { get; set; }

		public double GetDistance(Criteria second)
		{
			return Math.Sqrt(Math.Pow((Duration - second.Duration), 2) 
				+ Math.Pow((DurationBest - second.DurationBest), 2) 
				+ Math.Pow((DurationWorst - second.DurationWorst), 2)
				+ Math.Pow((InefficiencyTime - second.InefficiencyTime), 2) 
				+ Math.Pow((InefficiencyTimeBest - second.InefficiencyTimeBest), 2) 
				+ Math.Pow((InefficiencyTimeWorst - second.InefficiencyTimeWorst), 2));
		}
	}
}
