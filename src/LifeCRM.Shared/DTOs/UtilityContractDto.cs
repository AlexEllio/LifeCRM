namespace LifeCRM.Shared.DTOs
{
    public class UtilityContractDto
    {
        public Guid Id { get; set; }
        public string Category { get; set; } = string.Empty;     // Ej: "Agua", "Internet", "Electricidad"
        public string Alias { get; set; } = string.Empty;        // Ej: "Piso Málaga", "Casa Torre del Mar"
        public string ProviderName { get; set; } = string.Empty; // Ej: "Emasa", "O2", "Endesa"
        public string PlanName { get; set; } = string.Empty;     // Ej: "Fibra 500MB", "Tarifa Conecta"
        public DateTime? CommitmentEndDate { get; set; }         // Fin de permanencia
        public bool IsActive { get; set; }
    }
}
