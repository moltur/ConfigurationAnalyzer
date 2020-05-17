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

		public double GetDistance(Criteria other)
		{
			return Math.Sqrt(Math.Pow((Duration - other.Duration), 2) 
				+ Math.Pow((DurationBest - other.DurationBest), 2) 
				+ Math.Pow((DurationWorst - other.DurationWorst), 2)
				+ Math.Pow((InefficiencyTime - other.InefficiencyTime), 2) 
				+ Math.Pow((InefficiencyTimeBest - other.InefficiencyTimeBest), 2) 
				+ Math.Pow((InefficiencyTimeWorst - other.InefficiencyTimeWorst), 2));
		}
	}
}
