using ConfigurationAnalyzer.Domain.Models;
using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Domain.Interfaces
{
	public interface IConfigurationsService
	{
		IEnumerable<Configuration> GetAll();

		ConfigurationRunPropertiesProcessed Get(int id);

		IEnumerable<Configuration> GetBest(IEnumerable<int> ids, int method);
	}
}
