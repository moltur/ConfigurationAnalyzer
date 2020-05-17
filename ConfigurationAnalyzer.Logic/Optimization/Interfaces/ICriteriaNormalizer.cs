using ConfigurationAnalyzer.Logic.Optimization.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic.Optimization.Interfaces
{
	public interface ICriteriaNormalizer
	{
		IEnumerable<Criteria> Normalize(IEnumerable<Criteria> criterias);
	}
}
