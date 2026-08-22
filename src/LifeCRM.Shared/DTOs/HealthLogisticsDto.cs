namespace LifeCRM.Shared.DTOs
{
    public class HealthLogisticsDto
    {
        public Guid Id { get; set; }
        public string HealthCenterName { get; set; } = string.Empty; // Ej: "Centro de Salud Vélez-Sur"
        public string GeneralPractitioner { get; set; } = string.Empty;
        public string PrivateInsuranceName { get; set; } = string.Empty;
        public DateTime? DniExpiryDate { get; set; }
        public DateTime? DigitalCertificateExpiryDate { get; set; }
    }
}
