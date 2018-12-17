using System;
using System.Collections.Generic;

namespace BlogPage.Models
{
    public partial class Yorum
    {
        public int id { get; set; }
        public string Icerik { get; set; }
        public Nullable<System.Guid> YazarID { get; set; }
        public Nullable<int> MakaleID { get; set; }
        public Nullable<System.DateTime> EkelemeTarixi { get; set; }
        public virtual Makale Makale { get; set; }
        public virtual Yazar Yazar { get; set; }
    }
}
