using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long SamuraiId { get; set; }

        public virtual Samuraies Samurai { get; set; }
    }
}
