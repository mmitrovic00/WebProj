using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Projekat.Infrastructure;
using Projekat.Interfaces;
using Projekat.Mapping;
using Projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat
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
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projekat", Version = "v1" });
			});
		

		services.AddScoped<IUserService, UserService>();

		//registracija db contexta u kontejneru zavisnosti, njegov zivotni vek je Scoped
		     services.AddDbContext<WSDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebShopDatabase")));
                 //Registracija mapera u kontejneru, zivotni vek singleton
                 var mapperConfig = new MapperConfiguration(mc =>
		     	{
		     		mc.AddProfile(new MappingProfile());
		     	});
		     
		     IMapper mapper = mapperConfig.CreateMapper();
		     services.AddSingleton(mapper);
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projekat v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
