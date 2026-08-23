namespace LifeCRM.Api.Entities;

sealed class FinancialProductEntity
{
    public Guid Id { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public DateTime? InterestRateReviewDate { get; set; }
    public DateTime? CardExpiryDate { get; set; }
}