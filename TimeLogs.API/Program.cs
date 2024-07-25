using Microsoft.EntityFrameworkCore;
using TimeLogs.API.Infrastructure;
using TimeLogs.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options => options.AddPolicy("allow origin", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    }));

ServiceSettings.BuildServices(builder);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder
    .Services
    .AddDbContext<TimeLogsDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseRouting()
    .UseCors("allow origin");

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

DbMigrator.MigrateDatabase(connectionString);

app.InitializeDatabase();

app.Run();
