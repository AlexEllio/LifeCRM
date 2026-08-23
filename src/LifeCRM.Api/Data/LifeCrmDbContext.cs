using Microsoft.EntityFrameworkCore;
using LifeCRM.Api.Entities;

namespace LifeCRM.Api.Data;

public class LifeCrmDbContext : DbContext
{
    public LifeCrmDbContext(DbContextOptions<LifeCrmDbContext> options) : base(options) { }

    internal DbSet<UtilityContractEntity> UtilityContracts => Set<UtilityContractEntity>();
    internal DbSet<VehicleLogEntity> VehicleLogs => Set<VehicleLogEntity>();
    internal DbSet<HealthLogisticsEntity> HealthLogistics => Set<HealthLogisticsEntity>();
    internal DbSet<FinancialProductEntity> FinancialProducts => Set<FinancialProductEntity>();
}