using System.Net.NetworkInformation;

using MMLib.Ocelot.Provider.AppConfiguration;
using MMLib.SwaggerForOcelot.DependencyInjection;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Disposition")
    );
});


builder.Services.AddEndpointsApiExplorer();


builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddOcelotWithSwaggerSupport((o) =>
                       {
                           o.Folder = "./ApiGateways";
                       })
                       .AddEnvironmentVariables();



builder.Services.AddOcelot().AddAppConfiguration();
builder.Services.AddSwaggerForOcelot(builder.Configuration);


var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseCors(builder => builder.AllowCredentials());


app.UseRouting();

app.UseSwagger();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseStaticFiles();

app.UseSwaggerForOcelotUI(opt => { opt.RoutePrefix = string.Empty; }).UseOcelot().Wait();

app.Run();
