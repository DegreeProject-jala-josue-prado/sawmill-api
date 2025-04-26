namespace yume_api.src.repository.entities
{
    public class WoodSummary : IEntityBase
    {
        public Guid Id { get; set; }
        public string Month { get; set; } = "";
        public double InStock { get; set; }
        public double Sales { get; set; }
        public string Category { get; set; } = "";
    }
}