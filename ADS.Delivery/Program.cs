using ADS.Delivery.Cardapio.API.V1;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<IADSDRepositorioPratos, ADSDRepositorioPratos>();
builder.Services.AddScoped<IADSDRepositorioCategorias, ADSDRepositorioCategorias>();
builder.Services.AddScoped<IADSDAplicacaoPratos, ADSDAplicacaoPratos>();
builder.Services.AddScoped<IADSDAplicacaoCategorias, ADSDAplicacaoCategorias>();

builder.Services.AddControllers();
builder.Services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1.0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    // reporting api versions will return the headers
                    // "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                           new UrlSegmentApiVersionReader(),
                           new QueryStringApiVersionReader("api-version"),
                           new HeaderApiVersionReader("1-Version"),
                           new MediaTypeApiVersionReader("1-version"));
                })
            .AddMvc(
                options =>
                {
                    // automatically applies an api version based on the name of
                    // the defining controller's namespace
                    options.Conventions.Add(new VersionByNamespaceConvention());
                });

// Using InMemory Database (without connection string)
builder.Services.AddDbContext<ADSBDEFContextoBaseInMemory>(options =>
    options.UseInMemoryDatabase("BdTesteInMemory")
);

builder.Services.AddEndpointsApiExplorer();

var apiVersion = builder.Configuration.GetValue<string>("ApiVersion");

#region Swagger Documentation
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Akira Digital Solutions - Cardápio Delivery API",
        Version = "v1",
        Description = "This API is about a Delivery Menu registration made by the contracting part. The Contracting Part could be a Restaurant or even a small food delivery.",
        Contact = new OpenApiContact
        {
            Name = "Mateus Henrique",
            Email = "akiradigitalsolutionss@gmail.com",
            Url = new Uri("https://akiradigitalsolutions.com")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline
 app.UseSwagger();
 app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Akira Digital Solutions - Cardápio Delivery API v1");
        options.DocumentTitle = "Cardápio API Documentation";
        options.RoutePrefix = string.Empty;
    });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
