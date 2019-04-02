using System;

namespace Htp.Books.Data.Contracts.Entities
{
    public class HistoryLog : Entity<int>
    {
        public string Origin { get; set; }
        public string Actually { get; set; }
        public string EntityId { get; set; } //TODO: How work if entity Id is <TKey>?
        public string EntityType { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}