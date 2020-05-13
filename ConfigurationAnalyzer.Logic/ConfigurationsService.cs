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
					Name = "Первая конфигурация"
				},
				new Configuration
				{
					Id = 2,
					Name = "Вторая конфигурация"
				},
				new Configuration
				{
					Id = 3,
					Name = "Третья конфигурация"
				},
				new Configuration
				{
					Id = 4,
					Name = "Четвертая конфигурация"
				},
			};
		}

		public ConfigurationRunPropertiesProcessed GetConfiguration(long id)
		{
			return new ConfigurationRunPropertiesProcessed
			{
				Id = id,
				Configuration = new Configuration
				{
					Id = 2,
					Name = "Вторая конфигурация"
				},
				Duration = 458.5,
				DurationBest = 359.2,
				DurationWorst = 842.3,
				Cost = 180345.15,
				InefficiencyTime = 5658,
				InefficiencyTimeBest = 2153.84,
				InefficiencyTimeWorst = 8625,
				Resources = new List<ResourceRunProperties>
				{
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 1,
							Name = "Исполнитель",
							Cost = 60524.35
						},
						InUseTime = 120,
						InefficiencyTime = 458.5 - 120,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 2,
							Name = "Компьютер",
							Cost = 60524.35
						},
						InUseTime = 152,
						InefficiencyTime = 458.5 - 152,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 3,
							Name = "Принтер",
							Cost = 36584.2,
						},
						InUseTime = 4,
						InefficiencyTime = 458.5 - 4,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 4,
							Name = "САПР ТП",
							Cost = 83236.6
						},
						InUseTime = 401,
						InefficiencyTime = 458.5 - 401,
					},
				},
				Procedures = new List<ProcedureRunProperties>
				{
					new ProcedureRunProperties
					{
						Procedure =  new Procedure
						{
							Id = 1,
							Name = "Анализ исходных данных",
							Resources = new List<Resource>
							{
								new Resource
								{ 
									Id = 1,
									Name = "Исполнитель",
									Cost = 60524.35
								}
							}
						},
						Duration = 52.6,
						InefficiencyTime = 4
					},
					new ProcedureRunProperties
					{
						Procedure =  new Procedure
						{
							Id = 1,
							Name = "Формирование технологического маршрута",
							Resources = new List<Resource>
							{
								new Resource
								{
									Id = 4,
									Name = "САПР ТП",
									Cost = 83236.6
								},
								new Resource
								{
									Id = 2,
									Name = "Компьютер",
									Cost = 60524.35
								},
							}
						},
						Duration = 399.2,
						InefficiencyTime = 52
					},
					new ProcedureRunProperties
					{
						Procedure =  new Procedure
						{
							Id = 1,
							Name = "Формирование комплекта технологической документации",
							Resources = new List<Resource>
							{
								new Resource
								{
									Id = 4,
									Name = "САПР ТП",
									Cost = 83236.6
								},
								new Resource
								{
									Id = 2,
									Name = "Компьютер",
									Cost = 60524.35
								},
								new Resource
								{
									Id = 3,
									Name = "Принтер",
									Cost = 36584.2,
								},
							}
						},
						Duration = 6.8,
						InefficiencyTime = 2
					}
				}
			};

		}
	}
}
