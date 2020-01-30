using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Samuraies
    {
        public Samuraies()
        {
            Quotes = new HashSet<Quotes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? ClanId { get; set; }

        public virtual Clans Clan { get; set; }
        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
