using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Repository
{
    public class RepositoryPermission : RepositoryGeneric<Permission>, IRepositoryPermission
    {
        public RepositoryPermission(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
