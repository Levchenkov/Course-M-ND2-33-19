using Htp.Books.Common.Contracts;
using Newtonsoft.Json;

namespace Htp.Books.Common.Implementation
{
    public class JsonHistoryLogHandler<TEntity> : IHistoryLogHandler<TEntity>
    {
        public TEntity Deserialize(string jsonString)
        {
            var entity = JsonConvert.DeserializeObject<TEntity>(jsonString);
            return entity;
        }

        public string Serialize(TEntity entity)
        {
            var jsonString = JsonConvert.SerializeObject(entity);
            return jsonString;
        }
    }
}
