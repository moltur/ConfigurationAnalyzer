using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationAnalyzer.Logic
{
	public class ResourcesService : IResourcesService
	{
		public IEnumerable<ResourceRunProperties> Combine(IEnumerable<IEnumerable<ResourceRunProperties>> resourcesRuns)
		{
			var result = new List<ResourceRunProperties>();
			foreach (var run in resourcesRuns)
			{
				foreach (var resource in run)
				{
					var currentResource = result.FirstOrDefault(x => x.Resource.Id == resource.Resource.Id);
					if (currentResource == null)
					{
						currentResource = new ResourceRunProperties
						{
							Resource = new Resource
							{
								Id = resource.Resource.Id,
								Name = resource.Resource.Name,
								Cost = resource.Resource.Cost
							},
							InUseTime = resource.InUseTime,
							InefficiencyTime = resource.InefficiencyTime
						};
						result.Add(currentResource);
					}
					currentResource.InUseTime += resource.InUseTime;
					currentResource.InefficiencyTime += resource.InefficiencyTime;
				}
			}
			var resourcesCount = result.Count();

			return result.Select(x => CalculateParamsAverage(x, resourcesCount));
		}

		private ResourceRunProperties CalculateParamsAverage(ResourceRunProperties resource, int resourcesCount)
		{
			return new ResourceRunProperties
			{
				Resource = new Resource
				{
					Id = resource.Resource.Id,
					Name = resource.Resource.Name,
					Cost = resource.Resource.Cost
				},
				InUseTime = resource.InUseTime / resourcesCount,
				InefficiencyTime = resource.InefficiencyTime / resourcesCount
			};
		}
	}
}
