using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Models
{
    public class YayinEvi:BaseModel
    {
        public string Tel { get; set; }
        public string Adres { get; set;}

        public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public virtual ICollection<Yazar> Yazarlar { get; set; } = new List<Yazar>();
    }
}
