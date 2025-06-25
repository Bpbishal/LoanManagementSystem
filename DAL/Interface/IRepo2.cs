using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo2<T, ID>
    {
        IEnumerable<T> GetAll();
        T GetById(ID id);
        void Add(T entity);
        void Update(T entity);
        void Delete(ID id);
        void Save();
    }
}
