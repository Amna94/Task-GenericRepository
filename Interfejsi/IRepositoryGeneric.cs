using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Interfejsi
{
    public interface IRepositoryGeneric<T>
    {
        List<T> FindAll();
        void FindBy(T entity);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
