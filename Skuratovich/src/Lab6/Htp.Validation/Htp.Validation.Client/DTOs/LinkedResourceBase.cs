using System.Collections.Generic;

namespace Htp.Validation.Client.DTOs
{
    public abstract class LinkedResourceBase
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
