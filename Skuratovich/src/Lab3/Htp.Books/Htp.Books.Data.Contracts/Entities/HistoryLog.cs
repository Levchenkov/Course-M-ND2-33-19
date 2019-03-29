using System;
namespace Htp.Books.Data.Contracts.Entities
{
    public class HistoryLog : IEntity<int>
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Actually { get; set; }
        public int EntityId { get; set; } //TODO: How work if entity Id is <TKey>?
        public string EntityType { get; set; }
    }
}