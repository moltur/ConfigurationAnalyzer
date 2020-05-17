using ConfigurationAnalyzer.Api.Models;
using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	[EnableCors("AllowEverything")]
	public class ConfigurationsController : ControllerBase
	{

		private readonly ILogger<ConfigurationsController> _logger;
		private readonly IConfigurationsService _configurationsService;

		public ConfigurationsController(ILogger<ConfigurationsController> logger, IConfigurationsService configurationsService)
		{
			_logger = logger;
			_configurationsService = configurationsService;
		}

		[HttpGet("")]
		public ActionResult<IEnumerable<Configuration>> GetAll()
		{
			return Ok(_configurationsService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<ConfigurationRunPropertiesProcessed> Get(int id)
		{
			return Ok(_configurationsService.Get(id));
		}

		[HttpPost("best")]
		public ActionResult<IEnumerable<Configuration>> FindBest([FromBody] BestConfigurationRequest request)
		{
			return Ok(_configurationsService.GetBest(request.Ids, request.Method));
		}
	}
}
