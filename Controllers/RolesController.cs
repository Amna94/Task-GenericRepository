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
    [Route("api/roles")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRepositoryRole _repositoryRole;
        public RolesController(IRepositoryRole repositoryRole)
        {
            _repositoryRole = repositoryRole;
        }

        [HttpPost]

        public IActionResult Create([FromBody] Role roles)
        {
            _repositoryRole.Create(roles);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Remove([FromBody] Role roles)
        {

            _repositoryRole.Remove(roles);
            return Ok(roles);
        }
        [HttpGet]

        public IActionResult FindAll()
        {
            var roles = _repositoryRole.FindAll();
            return Ok(roles);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Role roles)
        {
            _repositoryRole.Update(roles);
            return Ok(roles);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy([FromHeader] Role roles)
        {
            _repositoryRole.FindBy(roles);
            return Ok(roles);
        }
    }
}
