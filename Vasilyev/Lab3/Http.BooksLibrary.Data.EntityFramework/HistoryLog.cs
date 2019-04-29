namespace Http.BooksLibrary.Data.EntityFramework
{
    public class HistoryLog
    {
        public int Id { get; set; }

        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValue { get; set; }
        public string ActualValue { get; set; }
    }
}