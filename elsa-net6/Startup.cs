using Elsa;
using elsa_net6;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Consumer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            var elsaSection = Configuration.GetSection("Elsa");

            services
                .AddElsa(elsa => elsa
                    //.AddConsoleActivities()
                    .AddHttpActivities()
                    //.AddQuartzTemporalActivities()
                    //.AddJavaScriptActivities()
                    .AddWorkflow<HelloWorldWorkflow>()
                    //.AddWorkflowsFrom<Startup>()
                   );

            services.AddElsaApiEndpoints();

            /*services.AddCors(cors => cors.AddDefaultPolicy(policy => policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .WithExposedHeaders("Content-Disposition"))
                );*/

            //RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthorization();

            //app.UseRouting();

            ConfigureEventBus(app);

            app
                //.UseCors()
                .UseHttpActivities();
                /*.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    // Elsa API Endpoints are implemented as regular ASP.NET Core API controllers.
                    endpoints.MapControllers();
                });*/

            
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            //var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<Tra>
        }
    }
}
