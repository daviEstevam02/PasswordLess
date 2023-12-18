using PasswordLess.Api.Configurations;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();

// Configuring the Swagger
builder.Services.AddSwaggerConfiguration();

// Configuring the MySQL
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configuring the AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configuring the Jwt for Authentication and Authorization
builder.Services.AddJwtConfiguration(builder.Configuration);

// Resolve Dependencies
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
