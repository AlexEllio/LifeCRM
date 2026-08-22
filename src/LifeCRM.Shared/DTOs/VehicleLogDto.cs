namespace LifeCRM.Shared.DTOs
{
    public class VehicleLogDto
    {
        public Guid Id { get; set; }
        public string Alias { get; set; } = string.Empty;             // Ej: "Moto", "Coche principal"
        public string InsuranceProvider { get; set; } = string.Empty; // Ej: "Mapfre"
        public string CoverageType { get; set; } = string.Empty;      // Ej: "Terceros con robo"
        public DateTime? InsuranceExpiryDate { get; set; }
        public DateTime? NextItvDate { get; set; }
        public int LastMaintenanceMileage { get; set; }
    }
}
