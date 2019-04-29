namespace Lab.Library.Data.Contracts.Entities
{
    public class HistoryLog
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValues { get; set; }
        public string ActualValues { get; set; }
    }
}
