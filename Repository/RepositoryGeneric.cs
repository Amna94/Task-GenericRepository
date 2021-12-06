using Amy_WebApplication.Interfejsi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Amy_WebApplication.Modeli;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;

namespace Amy_WebApplication.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        public readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public RepositoryGeneric(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_configuration.GetConnectionString("Database"));
            }
        }

        public void Create(string roleId, T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Insert<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Create(T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Insert<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> FindAll(string roleId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    List<T> list = dbConnection.Find<T>().ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    List<T> list = dbConnection.Find<T>().ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void FindBy(T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Get<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Remove(string roleId, T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Delete<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Delete<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Update<T>(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
