using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic
{
	public class ConfigurationsService : IConfigurationsService
	{

		private readonly IDataProvider<ConfigurationRunProperties, Configuration> _provider;

		private readonly IProceduresService _proceduresService;
		private readonly IResourcesService _resourcesService;

		private readonly IBestConfigurationCalculator _calculator;

		public ConfigurationsService(IDataProvider<ConfigurationRunProperties, Configuration> provider, IProceduresService proceduresService, IResourcesService resourcesService,
			IBestConfigurationCalculator calculator)
		{
			_provider = provider;
			_proceduresService = proceduresService;
			_resourcesService = resourcesService;
			_calculator = calculator;
		}

		public IEnumerable<Configuration> GetAll()
		{
			return _provider.GetAll();
		}

		public ConfigurationRunPropertiesProcessed Get(int id)
		{
			return CalculateConfigurationProperties(_provider.Get(id));
		}

		public IEnumerable<ConfigurationRunPropertiesProcessed> Get(IEnumerable<int> ids)
		{
			return ids.Select(Get).ToList();
		}

		public IEnumerable<Configuration> GetBest(IEnumerable<int> ids)
		{
			var configurations = Get(ids);
			var bestConfigurations = _calculator.Calculate(configurations);

			return configurations.Where(x => bestConfigurations.Any(y => y == x.Configuration.Id)).Select(x => x.Configuration).ToList();
		}

		private ConfigurationRunPropertiesProcessed CalculateConfigurationProperties(IEnumerable<ConfigurationRunProperties> runs)
		{
			int durationBest = int.MaxValue, durationWorst = 0, duration = 0, ineffBest = int.MaxValue, ineffWorst = 0, ineff = 0;
			foreach (var run in runs)
			{
				var currentDuration = run.Duration;
				CalculateDurations(currentDuration, ref durationBest, ref durationWorst, ref duration);

				var currentIneff = run.InefficiencyTime;
				CalculateInefficiency(currentIneff, ref ineffBest, ref ineffWorst, ref ineff);
			}

			return new ConfigurationRunPropertiesProcessed
			{
				Id = 0,
				Configuration = new Configuration
				{
					Id = runs.First().Configuration.Id,
					Name = runs.First().Configuration.Name
				},
				Duration = duration,
				DurationBest = durationBest,
				DurationWorst = durationWorst,
				InefficiencyTime = ineff,
				InefficiencyTimeBest = ineffBest,
				InefficiencyTimeWorst = ineffWorst,
				Cost = runs.First().Cost,
				Procedures = _proceduresService.Combine(runs.Select(x => x.Procedures)),
				Resources = _resourcesService.Combine(runs.Select(x => x.Resources))
			};
		}

		private void CalculateDurations(int currentDuration, ref int durationBest, ref int durationWorst, ref int duration)
		{
			if (currentDuration < durationBest)
			{
				durationBest = currentDuration;
			}
			if (currentDuration > durationWorst)
			{
				durationWorst = currentDuration;
			}

			duration += currentDuration;
		}

		private void CalculateInefficiency(int currentIneff, ref int ineffBest, ref int ineffWorst, ref int ineff)
		{
			if (currentIneff < ineffBest)
			{
				ineffBest = currentIneff;
			}
			if (currentIneff > ineffWorst)
			{
				ineffWorst = currentIneff;
			}

			ineff += currentIneff;
		}
	}
}
