using ConfigurationAnalyzer.DataAccess;
using ConfigurationAnalyzer.Domain.Interfaces;
using ConfigurationAnalyzer.Domain.Models;
using ConfigurationAnalyzer.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationAnalyzer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSingleton<IDataProvider<long, ConfigurationRunProperties>, FakeDataProvider>();

			services.AddTransient<IConfigurationsService, ConfigurationsService>();
			services.AddTransient<IResourcesService, ResourcesService>();
			services.AddTransient<IProceduresService, ProceduresService>();

			services.AddCors(options =>
			{
				options.AddPolicy(name: "AllowEverything",
								  builder =>
								  {
									  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
								  });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("AllowEverything");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
