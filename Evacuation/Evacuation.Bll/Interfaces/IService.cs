using Evacuation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Bll.Interfaces
{
    public interface IService<T> where T : class
    {
        void Create(T item);
        void Edit(T item);
        void Delete(T item);
        T Get(int id);
        IEnumerable<T> GetAll();        
        void Dispose();
    }
}
