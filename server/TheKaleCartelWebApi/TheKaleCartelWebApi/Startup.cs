using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TheKaleCartelWebApi.Data;
using TheKaleCartelWebApi.Repositories.Repository;

namespace TheKaleCartelWebApi
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
      services.AddDbContext<KaleDbContext>();
      services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "The Kale Cartel", Version = "v1" });
      });
      services.AddCors();
      services.AddAutoMapper(typeof(Startup));

     services.AddMvc();
      services.AddMvcCore().AddApiExplorer();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "The Kale Cartel V1");
      });
      app.UseCors(options => 
            options.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod()
        );
      app.UseMvc(routes =>
      {
        // SwaggerGen won't find controllers that are routed via this technique.
        routes.MapRoute("default", "{controller=KaleProfile}/{action=Index}/{id?}");
      });
    }
  }
}
