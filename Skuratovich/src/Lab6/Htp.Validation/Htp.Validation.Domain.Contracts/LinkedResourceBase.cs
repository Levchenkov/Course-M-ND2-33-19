using System.Collections.Generic;

namespace Htp.Validation.Domain.Contracts
{
    public abstract class LinkedResourceBase
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
