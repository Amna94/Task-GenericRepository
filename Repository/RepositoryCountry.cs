using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Repository
{
    public class RepositoryCountry : RepositoryGeneric<Country>, IRepositoryCountry
    {
        public RepositoryCountry(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
