using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MicroRabbit.Consumer.Api
{
    public class Program
    {
        public static void Main(String[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStaticWebAssets()
                    .UseStartup<Startup>();
                }).UseSerilog();
    }
}

/*using Elsa;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddElsa(options => options
        .AddEntityFrameworkStores(Configuration)
        .AddHttpActivities()
        .AddTimerActivities()
        .AddConsoleActivities()
        .AddQuartzTemporalActivities()
        .AddWorkflow<YourWorkflow>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/
