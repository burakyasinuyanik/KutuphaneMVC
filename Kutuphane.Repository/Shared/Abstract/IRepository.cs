using Kutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kutuphane.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Add(T item);
        void Update(T item);
      
        void RemoveRange(IEnumerable<T> items);
        void AddRange(IEnumerable<T> items);
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Save();
    }
}
