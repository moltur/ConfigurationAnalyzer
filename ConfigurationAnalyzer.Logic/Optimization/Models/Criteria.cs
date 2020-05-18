using System;

namespace ConfigurationAnalyzer.Logic.Optimization.Models
{
	public class Criteria
	{
		public int ConfigurationId { get; set; }

		public double Duration { get; set; }

		public double DurationBest { get; set; }

		public double DurationWorst { get; set; }

		public double InefficiencyTime { get; set; }

		public double InefficiencyTimeBest { get; set; }

		public double InefficiencyTimeWorst { get; set; }

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
