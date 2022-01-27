using System.Collections.Generic;

namespace Services.Models
{
    public class CastResultSelection
    {
        public int Id { get; set; }
        public ICollection<CastSelection> Cast { get; set; }
    }
}
