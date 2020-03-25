using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class CastResultSelection
    {
        public int Id { get; set; }
        public ICollection<CastSelection> Cast { get; set; }
    }
}
