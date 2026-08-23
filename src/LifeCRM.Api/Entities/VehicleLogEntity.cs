namespace LifeCRM.Api.Entities;

sealed class VehicleLogEntity
{
    public Guid Id { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string InsuranceProvider { get; set; } = string.Empty;
    public string CoverageType { get; set; } = string.Empty;
    public DateTime? InsuranceExpiryDate { get; set; }
    public DateTime? NextItvDate { get; set; }
    public int LastMaintenanceMileage { get; set; }
}