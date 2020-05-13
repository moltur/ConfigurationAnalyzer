using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Logic
{
	public class ConfigurationsService : IConfigurationsService
	{
		public IEnumerable<Configuration> GetAllConfigurations()
		{
			return new List<Configuration>
			{
				new Configuration
				{
					Id = 1,
					Name = "First"
				},
				new Configuration
				{
					Id = 2,
					Name = "Second"
				},
				new Configuration
				{
					Id = 3,
					Name = "Third"
				},
				new Configuration
				{
					Id = 4,
					Name = "Fourth"
				},
			};
		}

		public ConfigurationRunProperties GetConfiguration(long Id)
		{
			throw new System.NotImplementedException();
		}
	}
}
