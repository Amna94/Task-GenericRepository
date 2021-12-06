using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;
using System.Data;
using Abp.Authorization;


namespace Amy_WebApplication.Controllers
{
    [Route("api/roles/{roleId}/permissions")]
    [ApiController]
    public class RolePermissionController : Controller
    {
        private readonly IRepositoryRolePermission _repositoryRolePermission;
        public RolePermissionController(IRepositoryRolePermission repositoryRolePermission)
        {
            _repositoryRolePermission = repositoryRolePermission;
        }

        [HttpPost]
        [Route("{permissionId}")]
        public IActionResult Create(string RoleId, string PermissionId)
        {
            _repositoryRolePermission.Create(RoleId, PermissionId);
            return Ok();
        }

        [HttpDelete]
        [Route("{permissionId}")]
        public IActionResult Remove([FromRoute] string RoleId, [FromRoute] string PermissionId)
        {
            _repositoryRolePermission.Remove(RoleId, PermissionId);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] RolePermission rolePermission)
        {
            _repositoryRolePermission.Update(rolePermission);
            return Ok(rolePermission);
        }

        [HttpGet]
        public IActionResult FindAll(string RoleId)
        {
            var roles = _repositoryRolePermission.FindAll(RoleId);
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy(string id)
        {
            var roles =  _repositoryRolePermission.FindBy(id);
            return Ok(roles);
        }

    }
}
