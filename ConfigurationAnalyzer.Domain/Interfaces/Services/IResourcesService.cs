using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IResourcesService
	{
		IEnumerable<ResourceRunProperties> Combine(IEnumerable<IEnumerable<ResourceRunProperties>> procedureRuns);
	}
}
