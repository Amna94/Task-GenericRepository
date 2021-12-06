using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController : Controller
    {
        private readonly IRepositoryPermission _repositoryPermission;
        public PermissionsController(IRepositoryPermission repositoryPermission)
        {
            _repositoryPermission = repositoryPermission;
        }

        [HttpPost]

        public IActionResult Create([FromBody] Permission permissions)
        {
            _repositoryPermission.Create(permissions);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Remove([FromBody] Permission permissions)
        {

            _repositoryPermission.Remove(permissions);
            return Ok(permissions);
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var permissions = _repositoryPermission.FindAll();
            return Ok(permissions);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Permission permissions)
        {
            _repositoryPermission.Update(permissions);
            return Ok(permissions);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy([FromHeader] Permission permissions)
        {
            _repositoryPermission.FindBy(permissions);
            return Ok(permissions);
        }
    }
}
