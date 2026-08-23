using Microsoft.EntityFrameworkCore;
using LifeCRM.Api.Data;
using LifeCRM.Api.Endpoints;
using Dotmim.Sync;
using Dotmim.Sync.Sqlite;
using Dotmim.Sync.Web.Server;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=lifecrm_master.db";
var connectionString = "Data Source=lifecrm_master.db";
// Register SQLite EF Core Context
builder.Services.AddDbContext<LifeCrmDbContext>(options =>
    options.UseSqlite(connectionString));

// Dotmim.Sync Server Configuration
// Define the exact table names managed by your EF Core entities
var tablesToSync = new string[]
{
    nameof(LifeCrmDbContext.UtilityContracts),
    nameof(LifeCrmDbContext.VehicleLogs),
    nameof(LifeCrmDbContext.HealthLogistics),
    nameof(LifeCrmDbContext.FinancialProducts)
};
var setup = new SyncSetup(tablesToSync);
var provider = new SqliteSyncProvider(connectionString);

builder.Services.AddSyncServer(provider, setup);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUtilityEndpoints();

// 3. Map Dotmim.Sync HTTP endpoint (typically /api/sync)
// TODO: not working correctly, need to investigate further
//app.MapSyncServer();

// Automatic Database Migration on Startup (Handy for self-hosted Docker containers)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LifeCrmDbContext>();
    db.Database.EnsureCreated();
}

app.Run();