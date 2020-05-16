using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IProceduresService
	{
		IEnumerable<ProcedureRunProperties> Combine(IEnumerable<IEnumerable<ProcedureRunProperties>> procedureRuns);
	}
}
