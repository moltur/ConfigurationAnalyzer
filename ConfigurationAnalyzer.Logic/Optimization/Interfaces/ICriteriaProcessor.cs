using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization.Interfaces
{
	public interface ICriteriaProcessor
	{
		IEnumerable<Criteria> Normalize(IEnumerable<Criteria> criterias);

		Criteria FindMinValuesPerCriteria(IEnumerable<Criteria> criterias);
	}
}
