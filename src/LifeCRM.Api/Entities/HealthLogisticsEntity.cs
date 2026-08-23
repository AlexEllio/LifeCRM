namespace LifeCRM.Api.Entities;

sealed class HealthLogisticsEntity
{
    public Guid Id { get; set; }
    public string HealthCenterName { get; set; } = string.Empty;
    public string GeneralPractitioner { get; set; } = string.Empty;
    public string PrivateInsuranceName { get; set; } = string.Empty;
    public DateTime? DniExpiryDate { get; set; }
    public DateTime? DigitalCertificateExpiryDate { get; set; }
}