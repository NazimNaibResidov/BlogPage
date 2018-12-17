using System;
using System.Collections.Generic;

namespace BlogPage.Models
{
    public partial class Yazar
    {
        public Yazar()
        {
            this.Makales = new List<Makale>();
            this.Yorums = new List<Yorum>();
        }

        public System.Guid id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Mail { get; set; }
        public Nullable<System.DateTime> Tarixi { get; set; }
        public Nullable<int> ResimID { get; set; }
        public Nullable<bool> Aktivmi { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
        public virtual ICollection<Makale> Makales { get; set; }
        public virtual Resim Resim { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
