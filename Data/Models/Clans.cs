using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Clans
    {
        public Clans()
        {
            Samuraies = new HashSet<Samuraies>();
        }

        public long Id { get; set; }
        public string ClanName { get; set; }

        public virtual ICollection<Samuraies> Samuraies { get; set; }
    }
}
