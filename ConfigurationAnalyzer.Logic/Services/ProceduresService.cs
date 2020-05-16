using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic
{
	public class ProceduresService: IProceduresService
	{
		public IEnumerable<ProcedureRunProperties> Combine(IEnumerable<IEnumerable<ProcedureRunProperties>> procedureRuns)
		{
			var result = new List<ProcedureRunProperties>();
			foreach (var run in procedureRuns)
			{
				foreach (var procedure in run)
				{
					var currentProcedure = result.FirstOrDefault(x => x.Procedure.Id == procedure.Procedure.Id);
					if (currentProcedure == null)
					{
						currentProcedure = new ProcedureRunProperties
						{
							Procedure = new Procedure
							{
								Id = procedure.Procedure.Id,
								Name = procedure.Procedure.Name
							},
							Duration = procedure.Duration,
							InefficiencyTime = procedure.InefficiencyTime
						};
						result.Add(currentProcedure);
					}
					currentProcedure.Duration += procedure.Duration;
					currentProcedure.InefficiencyTime += procedure.InefficiencyTime;
				}
			}
			var proceduresCount = result.Count();

			return result.Select(x => CalculateParamsAverage(x, proceduresCount));
		}

		private ProcedureRunProperties CalculateParamsAverage(ProcedureRunProperties procedure, int proceduresCount)
		{
			return new ProcedureRunProperties
			{
				Procedure = new Procedure
				{
					Id = procedure.Procedure.Id,
					Name = procedure.Procedure.Name
				},
				Duration = procedure.Duration / proceduresCount,
				InefficiencyTime = procedure.InefficiencyTime / proceduresCount
			};
		}
	}
}
