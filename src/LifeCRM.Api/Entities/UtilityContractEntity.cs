namespace LifeCRM.Api.Entities;

sealed class UtilityContractEntity
{
    public Guid Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    public string PlanName { get; set; } = string.Empty;
    public DateTime? CommitmentEndDate { get; set; }
    public bool IsActive { get; set; }
}