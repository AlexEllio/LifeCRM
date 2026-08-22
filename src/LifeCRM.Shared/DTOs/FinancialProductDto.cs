namespace LifeCRM.Shared.DTOs
{
    public class FinancialProductDto
    {
        public Guid Id { get; set; }
        public string BankName { get; set; } = string.Empty;     // Ej: "BBVA", "Openbank"
        public string ProductType { get; set; } = string.Empty;  // Ej: "Cuenta Nómina", "Hipoteca Fija"
        public DateTime? InterestRateReviewDate { get; set; }    // Fecha de revisión del tipo de interés
        public DateTime? CardExpiryDate { get; set; }
    }
}
