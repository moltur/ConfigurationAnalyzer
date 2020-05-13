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
			if(id == 2)
			return new ConfigurationRunPropertiesProcessed
			{
				Id = 2,
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
							Id = 2,
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
							Id = 3,
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
			else 
			return new ConfigurationRunPropertiesProcessed
			{
				Id = 3,
				Configuration = new Configuration
				{
					Id = 3,
					Name = "Третья конфигурация"
				},
				Duration = 521.4,
				DurationBest = 380.2,
				DurationWorst = 620.7,
				Cost = 250242.2,
				InefficiencyTime = 3890,
				InefficiencyTimeBest = 19953.7,
				InefficiencyTimeWorst = 4521.6,
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
						InUseTime = 142,
						InefficiencyTime = 521.4 - 140,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 2,
							Name = "Компьютер",
							Cost = 60524.35
						},
						InUseTime = 220.8,
						InefficiencyTime = 521.4 - 220.8,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 3,
							Name = "Принтер",
							Cost = 36584.2,
						},
						InUseTime = 5.3,
						InefficiencyTime = 521.4 - 5.3,
					},
					new ResourceRunProperties
					{
						Resource = new Resource
						{
							Id = 4,
							Name = "САПР ТП",
							Cost = 83236.6
						},
						InUseTime = 368.2,
						InefficiencyTime = 521.4 - 368.2,
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
						Duration = 78.6,
						InefficiencyTime = 2
					},
					new ProcedureRunProperties
					{
						Procedure =  new Procedure
						{
							Id = 2,
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
						Duration = 430.8,
						InefficiencyTime = 72
					},
					new ProcedureRunProperties
					{
						Procedure =  new Procedure
						{
							Id = 3,
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
						Duration = 15,
						InefficiencyTime = 6
					}
				}
			};

		}
	}
}
