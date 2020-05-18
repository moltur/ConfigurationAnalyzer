using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization.Interfaces;
using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic.Optimization
{
	public class ConcessionOptimizer: IConcessionOptimizer
	{
		private IList<double> Concessions { get; set; }

		private IList<double> CurrentBest { get; set; }

		private readonly IConverter<ConfigurationRunPropertiesProcessed, Criteria> _converter;

		public ConcessionOptimizer(IConverter<ConfigurationRunPropertiesProcessed, Criteria> converter)
		{
			_converter = converter;
		}

		public IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items)
		{
			var criteriaArr = items.Select(_converter.Convert).Select(SetOrder);
			Concessions = CalculateConcessions(criteriaArr);


			CurrentBest = criteriaArr.First();
			for (var i = 0; i < criteriaArr.Count(); i++)
			{
				Step(criteriaArr, i);
			}

			return new List<int>
			{
				(int)CurrentBest[7]
			};
		}

		private void Step(IEnumerable<IList<double>> items, int stepNum)
		{
			var currentBestValue = CurrentBest[stepNum];
			var newBest = CurrentBest;
			foreach (var item in items)
			{
				if (item[stepNum] < currentBestValue)
				{
					var i = stepNum - 1;
					while (i >= 0 && CheckItem(item, i))
					{
						i--;
					}
					if (i < 0)
					{
						currentBestValue = item[stepNum];
						newBest = item;
					}
				}
			}
			CurrentBest = newBest;
		}

		private bool CheckItem(IList<double> item, int i)
		{
			if (item[i] > CurrentBest[i] + Concessions[i])
				return false;
			return true;
		}
		private IList<double> CalculateConcessions(IEnumerable<IList<double>> items)
		{
			var result = Enumerable.Repeat((double)0, 7).ToList();

			foreach (var item in items)
			{
				for (var i = 0; i < result.Count() - 1; i++)
				{
					result[i] += item[i];
				}
			}
			return result.Select(x => x / items.Count() * 0.2).ToList();
		}

		private IList<double> SetOrder(Criteria item)
		{
			return new List<double>
			{
				item.Duration,
				(double)item.Cost,
				item.InefficiencyTime,
				item.DurationWorst,
				item.InefficiencyTimeWorst,
				item.DurationBest,
				item.InefficiencyTimeBest,
				item.ConfigurationId
			};
		}
	}

	public interface IConcessionOptimizer
	{
		IEnumerable<int> Calculate(IEnumerable<ConfigurationRunPropertiesProcessed> items);
	}
}
