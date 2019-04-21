using System.Collections.Generic;

namespace Htp.Validation.Domain.Contracts
{
    public class LinkedCollectionResourceWrapper<TModel> : LinkedResourceBase
    {
        public IEnumerable<TModel> Value { get; set; }

        public LinkedCollectionResourceWrapper(IEnumerable<TModel> value)
        {
            Value = value;
        }
    }
}
