using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelTest2.Models
{
  public  interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        T Delete(int id);
    }
}
