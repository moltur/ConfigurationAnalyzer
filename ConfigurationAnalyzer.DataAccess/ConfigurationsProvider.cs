using ConfigurationAnalyzer.DataAccess.Models;
using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.DataAccess
{
	public class ConfigurationsProvider : IDataProvider<ConfigurationRunProperties, Configuration>
	{
		private readonly DB_A26EBE_processimContext _context;
		private readonly ILogger _logger;

		public ConfigurationsProvider(DB_A26EBE_processimContext context, ILogger<ConfigurationsProvider> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IEnumerable<ConfigurationRunProperties> Get(int id)
		{
			var result = new List<ConfigurationRunProperties>();

			var simulations = _context.SimulationHistory
				.Include(x => x.SimulationName)
				.Include(x => x.ProcedureHistory)
				.Include(x => x.ResourceHistory)
				.Where(x => x.SimulationNameId == id)
				.ToList();

			for (var i = 0; i < simulations.Count(); i++)
			{
				var curr = simulations[i];
				result.Add(new ConfigurationRunProperties
				{
					Id = i + 1,
					Configuration = new Configuration
					{
						Id = curr.SimulationName.SimulationNameId,
						Name = curr.SimulationName.Name
					},
					Duration = curr.Duration,
					InefficiencyTime = curr.WaitingTime,
					Cost = curr.TotalCost,
					Resources = curr.ResourceHistory.Select(x => new ResourceRunProperties
					{
						Resource = new Domain.Models.Resource
						{
							Id = x.ResourceId,
							Name = x.ResourceName,
							Cost = x.Cost
						},
						InUseTime = x.UseTime,
						InefficiencyTime = x.Downtime
					}),
					Procedures = curr.ProcedureHistory.Select(x => new ProcedureRunProperties
					{
						Procedure = new Procedure
						{
							Id = x.ProcedureName,
							Name = x.ProcedureAlias
						},
						Duration = x.EndTime - x.StartTime,
						InefficiencyTime = x.WaitingTime
					})
				});
			}

			return result;
		}

		public IEnumerable<Configuration> GetAll()
		{
			return _context.SimulationName.Select(x => new Configuration
			{
				Id = x.SimulationNameId,
				Name = x.Name
			}).ToList();
		}
	}
}
