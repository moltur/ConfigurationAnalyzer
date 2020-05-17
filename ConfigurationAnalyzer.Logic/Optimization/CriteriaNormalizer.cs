using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class CriteriaNormalizer : ICriteriaNormalizer
	{
		private const double eps = 0.001;
		public IEnumerable<Criteria> Normalize(IEnumerable<Criteria> criterias)
		{
			var minValues = Enumerable.Repeat(double.MaxValue, 7).ToList().ToList();
			var maxValues = Enumerable.Repeat((double)0, 7).ToList();

			FindMinAndMaxValues(criterias, minValues, maxValues);

			var result = new List<Criteria>();

			foreach (var criteria in criterias)
			{
				result.Add(new Criteria
				{
					ConfigurationId = criteria.ConfigurationId,
					Duration = (maxValues[0] - minValues[0])< eps ? criteria.Duration:(int)((maxValues[0] - criteria.Duration) / (maxValues[0] - minValues[0])),
					DurationBest = (maxValues[1] - minValues[1]) < eps ? criteria.DurationBest : (int)((maxValues[1] - criteria.DurationBest) / (maxValues[1] - minValues[1])),
					DurationWorst = (maxValues[2] - minValues[2]) < eps ? criteria.DurationWorst : (int)((maxValues[2] - criteria.DurationWorst) / (maxValues[2] - minValues[2])),
					InefficiencyTime = (maxValues[3] - minValues[3]) < eps ? criteria.InefficiencyTime : (int)((maxValues[3] - criteria.InefficiencyTime) / (maxValues[3] - minValues[3])),
					InefficiencyTimeBest = (maxValues[4] - minValues[4]) < eps ? criteria.InefficiencyTimeBest : (int)((maxValues[4] - criteria.InefficiencyTimeBest) / (maxValues[4] - minValues[4])),
					InefficiencyTimeWorst = (maxValues[5] - minValues[5]) < eps ? criteria.InefficiencyTimeWorst : (int)((maxValues[5] - criteria.InefficiencyTimeWorst) / (maxValues[5] - minValues[5])),
					Cost = (maxValues[6] - minValues[6]) < eps ? criteria.Cost : (decimal)((maxValues[6] - (double)criteria.Cost) / (maxValues[6] - minValues[6])),
				});
			}

			return result;
		}

		private void FindMinAndMaxValues(IEnumerable<Criteria> criterias, IList<double> min, IList<double> max)
		{
			foreach (var criteria in criterias)
			{
				if (criteria.Duration < min[0])
				{
					min[0] = criteria.Duration;
				}
				if (criteria.Duration > max[0])
				{
					max[0] = criteria.Duration;
				}

				if (criteria.DurationBest < min[1])
				{
					min[1] = criteria.DurationBest;
				}
				if (criteria.DurationBest > max[1])
				{
					max[1] = criteria.DurationBest;
				}

				if (criteria.DurationWorst < min[2])
				{
					min[2] = criteria.DurationWorst;
				}
				if (criteria.DurationWorst > max[2])
				{
					max[2] = criteria.DurationWorst;
				}

				if (criteria.InefficiencyTime < min[3])
				{
					min[3] = criteria.InefficiencyTime;
				}
				if (criteria.InefficiencyTime > max[3])
				{
					max[3] = criteria.InefficiencyTime;
				}

				if (criteria.InefficiencyTimeBest < min[4])
				{
					min[4] = criteria.InefficiencyTimeBest;
				}
				if (criteria.InefficiencyTimeBest > max[4])
				{
					max[4] = criteria.InefficiencyTimeBest;
				}

				if (criteria.InefficiencyTimeWorst < min[5])
				{
					min[5] = criteria.InefficiencyTimeWorst;
				}
				if (criteria.InefficiencyTimeWorst > max[5])
				{
					max[5] = criteria.InefficiencyTimeWorst;
				}

				if ((double)criteria.Cost < min[6])
				{
					min[6] = (double)criteria.Cost;
				}
				if ((double)criteria.Cost > max[6])
				{
					max[6] = (double)criteria.Cost;
				}
			}
		}
	}
}
