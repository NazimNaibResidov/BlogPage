using System;
using System.Collections.Generic;

namespace BlogPage.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            this.Makales = new List<Makale>();
        }

        public int id { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Makale> Makales { get; set; }
    }
}
