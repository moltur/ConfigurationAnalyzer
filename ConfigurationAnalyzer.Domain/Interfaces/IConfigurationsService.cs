using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IConfigurationsService
	{
		IEnumerable<Configuration> GetAllConfigurations();

		ConfigurationRunProperties GetConfiguration(long Id);
	}
}
