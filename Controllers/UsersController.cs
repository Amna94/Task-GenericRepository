using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Amy_WebApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Amy_WebApplication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IRepositoryUsers _repositoryUsers;
        private IConfiguration _config;
        public UsersController(IConfiguration config, RepositoryUsers repositoryUsers)
        {
            _config = config;
            _repositoryUsers = repositoryUsers;

        }

        [HttpPost]

        public IActionResult Create([FromBody] Users users)
        {
            _repositoryUsers.Create(users);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Remove([FromBody] Users users)
        {
            _repositoryUsers.Remove(users);
            return Ok(users);
        }
        [HttpGet]
        [Authorize]
        public IActionResult FindAll()
        {
            var users = _repositoryUsers.FindAll();
            return Ok(users);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Users users)
        {
            _repositoryUsers.Update(users);
            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy([FromHeader] Users users)
        {
            _repositoryUsers.FindBy(users);
            return Ok(users);
        }
    }
}
