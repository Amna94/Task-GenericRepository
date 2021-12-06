using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Npgsql;
using System.Configuration;

namespace Amy_WebApplication.Repository
{
    public class RepositoryCity : RepositoryGeneric<City>, IRepositoryCity
    {
        public RepositoryCity(IConfiguration configuration)
            : base(configuration)

        {

        }
    }
}
