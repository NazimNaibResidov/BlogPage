using System;
using System.Collections.Generic;

namespace BlogPage.Models
{
    public partial class Resim
    {
        public Resim()
        {
            this.Makales = new List<Makale>();
            this.Yazars = new List<Yazar>();
        }

        public int id { get; set; }
        public string Adi { get; set; }
        public string Samll { get; set; }
        public string Midel { get; set; }
        public string Big { get; set; }
        public string Yazar { get; set; }
        public string Slider { get; set; }
        public virtual ICollection<Makale> Makales { get; set; }
        public virtual ICollection<Yazar> Yazars { get; set; }
    }
}
