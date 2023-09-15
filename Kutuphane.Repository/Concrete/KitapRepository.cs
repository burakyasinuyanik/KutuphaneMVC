using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Concrete
{
    public class KitapRepository:Repository<Kitap>,IKitapRepository
    {
        private readonly KutuphaneContext _db;

        public KitapRepository(KutuphaneContext db):base(db) 
        {
            _db = db;
        } 
       

        IQueryable<Kitap> IKitapRepository.GetAll()
        {
            return _db.Kitaplar.Include(k => k.Yazarlar).Include(k => k.YayinEvleri).Where(k=>k.IsDeleted==false);
        }
    }
}
