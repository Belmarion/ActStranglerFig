using Microsoft.OpenApi.Models;
using System.Reflection;
using UniSabana.ApiLibreriaKmlMono;

var builder = WebApplication.CreateBuilder(args);

Assembly? assembly = Assembly.GetEntryAssembly();
AssemblyInformationalVersionAttribute? versionAttribute = assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
string? assemblyVersion = versionAttribute?.InformationalVersion;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Following code to avoid swagger generation error 
    //due to same method name in different versions.
    options.ResolveConflictingActions(descriptions => descriptions.First());

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = $"v{assemblyVersion} - {builder.Configuration.GetSection("Environment").Value}",
        Title = Resource.Title,
        Description = Resource.Description,
        TermsOfService = new Uri(uriString: $"https://www.unisabana.edu.co/"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri($"https://www.unisabana.edu.co/")
        },
        License = new OpenApiLicense
        {
            Name = "Apache License, Version 2.0",
            Url = new Uri($"https://www.unisabana.edu.co/")
        }
    });

    //options.OperationFilter<SwaggerParameterFilters>();
    //options.DocumentFilter<SwaggerVersionMapping>();

    // Set the comments path for the Swagger JSON and UI.
    string xmlFile = "UniSabana.ApiLibreriaKmlMono.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();


app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json")
        .UseSwaggerUI(c =>
        {
            c.DocumentTitle = Resource.DocumentTitle;
            c.HeadContent = Resource.HeadContent;
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"UniSabana.ApiLibreriaKml API v{assemblyVersion}");
            c.InjectStylesheet("/assets/swagger-ui.css");
            c.DisplayRequestDuration();
        });

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
