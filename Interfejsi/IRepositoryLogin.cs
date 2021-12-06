using Amy_WebApplication.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Interfejsi
{
    public interface IRepositoryLogin
    {
        void Insert(Login entity);
        Task<IEnumerable<Login>> GetAll();
        Task<Login> GetUsernameAndPassword(string username, string password);
    }
}
