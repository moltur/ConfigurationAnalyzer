using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class CriteriaProcessor : ICriteriaProcessor
	{
		private const double eps = 0.001;
		public IEnumerable<Criteria> Normalize(IEnumerable<Criteria> criterias)
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

			FindMinAndMaxValues(criterias, minValues, maxValues);

			var result = new List<Criteria>();

			foreach (var criteria in criterias)
			{
				result.Add(new Criteria
				{
					ConfigurationId = criteria.ConfigurationId,
					Duration = (maxValues.Duration - minValues.Duration) < eps ? criteria.Duration : ((maxValues.Duration - criteria.Duration) / (maxValues.Duration - minValues.Duration)),
					DurationBest = (maxValues.DurationBest - minValues.DurationBest) < eps ? criteria.DurationBest : ((maxValues.DurationBest - criteria.DurationBest) / (maxValues.DurationBest - minValues.DurationBest)),
					DurationWorst = (maxValues.DurationWorst - minValues.DurationWorst) < eps ? criteria.DurationWorst : ((maxValues.DurationWorst - criteria.DurationWorst) / (maxValues.DurationWorst - minValues.DurationWorst)),
					InefficiencyTime = (maxValues.InefficiencyTime - minValues.InefficiencyTime) < eps ? criteria.InefficiencyTime : ((maxValues.InefficiencyTime - criteria.InefficiencyTime) / (maxValues.InefficiencyTime - minValues.InefficiencyTime)),
					InefficiencyTimeBest = (maxValues.InefficiencyTimeBest - minValues.InefficiencyTimeBest) < eps ? criteria.InefficiencyTimeBest : ((maxValues.InefficiencyTimeBest - criteria.InefficiencyTimeBest) / (maxValues.InefficiencyTimeBest - minValues.InefficiencyTimeBest)),
					InefficiencyTimeWorst = (maxValues.InefficiencyTimeWorst - minValues.InefficiencyTimeWorst) < eps ? criteria.InefficiencyTimeWorst : ((maxValues.InefficiencyTimeWorst - criteria.InefficiencyTimeWorst) / (maxValues.InefficiencyTimeWorst - minValues.InefficiencyTimeWorst)),
					Cost = (maxValues.Cost - minValues.Cost) < (decimal)eps ? criteria.Cost : ((maxValues.Cost - criteria.Cost) / (maxValues.Cost - minValues.Cost)),
				});
			}

			return result;
		}

		public Criteria FindMinValuesPerCriteria(IEnumerable<Criteria> criterias)
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

			FindMinAndMaxValues(criterias, minValues, maxValues);
			return minValues;
		}

		private void FindMinAndMaxValues(IEnumerable<Criteria> criterias, Criteria min, Criteria max)
		{
			foreach (var criteria in criterias)
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
