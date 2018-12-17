using System;
using System.Collections.Generic;

namespace BlogPage.Models
{
    public partial class Makale
    {
        public Makale()
        {
            this.Yorums = new List<Yorum>();
        }

        public int id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Kodlar { get; set; }
        public System.DateTime EkelemeTarixi { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<int> GoruntlemeSayi { get; set; }
        public Nullable<int> Begeni { get; set; }
        public Nullable<System.Guid> YazarID { get; set; }
        public Nullable<int> ResimID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Resim Resim { get; set; }
        public virtual Yazar Yazar { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
