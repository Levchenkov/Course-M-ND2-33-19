using System;
namespace Htp.Books.Data.Contracts.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
