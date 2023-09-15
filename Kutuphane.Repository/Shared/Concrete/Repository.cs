using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbSet<T> _dbSet;
        private readonly KutuphaneContext _db;

        public Repository(KutuphaneContext db)
        {
            _db = db;
            _dbSet=_db.Set<T>();
        }
        void IRepository<T>.Add(T item)
        {
            _dbSet.Add(item);
        }

        void IRepository<T>.AddRange(IEnumerable<T> items)
        {
            _dbSet.AddRange(items);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
           return _dbSet.Where(t=>t.IsDeleted==false).ToList();
        }

        T IRepository<T>.GetById(int id)
        {
           return _dbSet.Find(id);
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
           return _dbSet.FirstOrDefault(filter);
        }

        void IRepository<T>.Remove(T item)
        {
            item.IsDeleted = true;
            _dbSet.Update(item);
        }

       

        void IRepository<T>.RemoveRange(IEnumerable<T> items)
        {
            foreach (T item in items)
                item.IsDeleted = true;
            _dbSet.UpdateRange(items);
        }

        void IRepository<T>.Save()
        {
            _db.SaveChanges();
        }

        void IRepository<T>.Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
