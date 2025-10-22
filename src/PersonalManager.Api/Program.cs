using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using PersonalManager.Api.Middleware;
using PersonalManager.Application.Commons.Extensions;
using PersonalManager.Infrastructure.Commons.Extensions;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PersonalManager API",
        Version = "v1",
        Description = "API pour la gestion des employés et des jobs"
    });
});

var app = builder.Build();

//Auto-Migration
using (IServiceScope scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PgSqlContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalManager API v1");
        c.RoutePrefix = string.Empty; // Swagger accessible à la racine (/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandling>();

app.MapControllers();

app.Run();
