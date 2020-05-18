using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class CriteriaProcessor : ICriteriaProcessor
	{
		private const double eps = 0.001;
		public IEnumerable<Criteria> Normalize(IEnumerable<Criteria> items)
		{
			var minValues = new Criteria
			{
				Duration = double.MaxValue,
				DurationBest = double.MaxValue,
				DurationWorst = double.MaxValue,
				InefficiencyTime = double.MaxValue,
				InefficiencyTimeBest = double.MaxValue,
				InefficiencyTimeWorst = double.MaxValue,
				Cost = decimal.MaxValue
			};

			var maxValues = new Criteria
			{
				Duration = 0,
				DurationBest = 0,
				DurationWorst = 0,
				InefficiencyTime = 0,
				InefficiencyTimeBest = 0,
				InefficiencyTimeWorst = 0,
				Cost = 0
			};

			FindMinAndMaxValues(items, minValues, maxValues);

			var result = new List<Criteria>();

			foreach (var criteria in items)
			{
				result.Add(new Criteria
				{
					ConfigurationId = criteria.ConfigurationId,
					Duration = (maxValues.Duration - minValues.Duration) < eps ? criteria.Duration : ((criteria.Duration - minValues.Duration) / (maxValues.Duration - minValues.Duration)),
					DurationBest = (maxValues.DurationBest - minValues.DurationBest) < eps ? criteria.DurationBest : ((criteria.DurationBest - minValues.DurationBest) / (maxValues.DurationBest - minValues.DurationBest)),
					DurationWorst = (maxValues.DurationWorst - minValues.DurationWorst) < eps ? criteria.DurationWorst : ((criteria.DurationWorst - minValues.DurationWorst) / (maxValues.DurationWorst - minValues.DurationWorst)),
					InefficiencyTime = (maxValues.InefficiencyTime - minValues.InefficiencyTime) < eps ? criteria.InefficiencyTime : ((criteria.InefficiencyTime - minValues.InefficiencyTime) / (maxValues.InefficiencyTime - minValues.InefficiencyTime)),
					InefficiencyTimeBest = (maxValues.InefficiencyTimeBest - minValues.InefficiencyTimeBest) < eps ? criteria.InefficiencyTimeBest : ((criteria.InefficiencyTimeBest - minValues.InefficiencyTimeBest) / (maxValues.InefficiencyTimeBest - minValues.InefficiencyTimeBest)),
					InefficiencyTimeWorst = (maxValues.InefficiencyTimeWorst - minValues.InefficiencyTimeWorst) < eps ? criteria.InefficiencyTimeWorst : ((criteria.InefficiencyTimeWorst - minValues.InefficiencyTimeWorst) / (maxValues.InefficiencyTimeWorst - minValues.InefficiencyTimeWorst)),
					Cost = (maxValues.Cost - minValues.Cost) < (decimal)eps ? criteria.Cost : ((criteria.Cost - minValues.Cost) / (maxValues.Cost - minValues.Cost)),
				});
			}

			return result;
		}

		public Criteria FindMinValuesPerCriteria(IEnumerable<Criteria> items)
		{
			var minValues = new Criteria
			{
				Duration = int.MaxValue,
				DurationBest = int.MaxValue,
				DurationWorst = int.MaxValue,
				InefficiencyTime = int.MaxValue,
				InefficiencyTimeBest = int.MaxValue,
				InefficiencyTimeWorst = int.MaxValue,
				Cost = decimal.MaxValue
			};

			var maxValues = new Criteria
			{
				Duration = 0,
				DurationBest = 0,
				DurationWorst = 0,
				InefficiencyTime = 0,
				InefficiencyTimeBest = 0,
				InefficiencyTimeWorst = 0,
				Cost = 0
			};

			FindMinAndMaxValues(items, minValues, maxValues);
			return minValues;
		}

		private void FindMinAndMaxValues(IEnumerable<Criteria> items, Criteria min, Criteria max)
		{
			foreach (var criteria in items)
			{
				if (criteria.Duration < min.Duration)
				{
					min.Duration = criteria.Duration;
				}
				if (criteria.Duration > max.Duration)
				{
					max.Duration = criteria.Duration;
				}

				if (criteria.DurationBest < min.DurationBest)
				{
					min.DurationBest = criteria.DurationBest;
				}
				if (criteria.DurationBest > max.DurationBest)
				{
					max.DurationBest = criteria.DurationBest;
				}

				if (criteria.DurationWorst < min.DurationWorst)
				{
					min.DurationWorst = criteria.DurationWorst;
				}
				if (criteria.DurationWorst > max.DurationWorst)
				{
					max.DurationWorst = criteria.DurationWorst;
				}

				if (criteria.InefficiencyTime < min.InefficiencyTime)
				{
					min.InefficiencyTime = criteria.InefficiencyTime;
				}
				if (criteria.InefficiencyTime > max.InefficiencyTime)
				{
					max.InefficiencyTime = criteria.InefficiencyTime;
				}

				if (criteria.InefficiencyTimeBest < min.InefficiencyTimeBest)
				{
					min.InefficiencyTimeBest = criteria.InefficiencyTimeBest;
				}
				if (criteria.InefficiencyTimeBest > max.InefficiencyTimeBest)
				{
					max.InefficiencyTimeBest = criteria.InefficiencyTimeBest;
				}

				if (criteria.InefficiencyTimeWorst < min.InefficiencyTimeWorst)
				{
					min.InefficiencyTimeWorst = criteria.InefficiencyTimeWorst;
				}
				if (criteria.InefficiencyTimeWorst > max.InefficiencyTimeWorst)
				{
					max.InefficiencyTimeWorst = criteria.InefficiencyTimeWorst;
				}

				if (criteria.Cost < min.Cost)
				{
					min.Cost = criteria.Cost;
				}
				if (criteria.Cost > max.Cost)
				{
					max.Cost = criteria.Cost;
				}
			}
		}
	}
}
