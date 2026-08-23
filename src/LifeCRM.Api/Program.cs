using Microsoft.EntityFrameworkCore;
using LifeCRM.Api.Data;
using LifeCRM.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Register SQLite EF Core Context
builder.Services.AddDbContext<LifeCrmDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=lifecrm_master.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUtilityEndpoints();

// Automatic Database Migration on Startup (Handy for self-hosted Docker containers)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LifeCrmDbContext>();
    db.Database.EnsureCreated();
}

app.Run();