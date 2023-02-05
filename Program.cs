using Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services
    .AddPooledDbContextFactory<ApplicationDbContext>(
        options => options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .EnableDetailedErrors(builder.Environment.IsDevelopment())
            .EnableSensitiveDataLogging(builder.Environment.IsDevelopment()));
// --

var app = builder.Build();

// Reproduction.
app.MapGet("/", (IDbContextFactory<ApplicationDbContext> dbContextFactory) =>
{
    var dbContext = dbContextFactory.CreateDbContext();

    var title = "title";

    return dbContext.Articles.Where(a => a.Title == title);
});

app.Run();
