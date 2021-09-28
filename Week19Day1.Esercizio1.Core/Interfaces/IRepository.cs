using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day1.Esercizio1.Core.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> Fetch();
        public int Insert(T item);
    }
}
