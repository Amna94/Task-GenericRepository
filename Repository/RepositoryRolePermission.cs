using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Repository
{
    public class RepositoryRolePermission : RepositoryGeneric<RolePermission>, IRepositoryRolePermission
    {
        public RepositoryRolePermission(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void Create(string roleId, string permissionId)
        {
            throw new NotImplementedException();
        }

        public void Delete(string roleId, string permissionId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM role_permissions WHERE role_id=@roleId, permission_id=@permissionId";
                    dbConnection.Execute(query, new { roleId, permissionId });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task FindBy(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RolePermission>> GetAll(string roleId)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM role_permissions WHERE role_id=@roleId";
                    return await dbConnection.QueryAsync<RolePermission>(query, new { roleId });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<RolePermission>> GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT role_id as role_id,permission_id as permission_id FROM role_permissions WHERE role_id=@id";
                    return await dbConnection.QueryAsync<RolePermission>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(string roleId, string permissionId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO role_permissions(role_id,permission_id) VALUES(@RoleId,@PermissionId) ";
                    dbConnection.Execute(query, new { roleId, permissionId });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Remove(string roleId, string permissionId)
        {
            throw new NotImplementedException();
        }

        Task IRepositoryRolePermission.FindAll(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
