using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task3_WPF_
{
    interface IRepository<T> where  T: class
    {
        IEnumerable<T> GetAll();
        T GetById(string sushi_name);
        void Create(T item);
        void Update(T item);
        void DeleteById(string sushi_name);
    }
  
 
}
