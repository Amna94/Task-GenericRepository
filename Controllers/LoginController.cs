using Amy_WebApplication.Interfejsi;
using Amy_WebApplication.Modeli;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Amy_WebApplication.Controllers
{
    [Authorize]
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly IRepositoryLogin _repositoryLogin;

        public LoginController(IConfiguration config, IRepositoryLogin repositoryLogin)
        {
            _config = config;
            _repositoryLogin = repositoryLogin;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration([FromBody] Login model)
        {
            _repositoryLogin.Insert(model);
            return Ok(model);
        }


        [HttpGet]
        [Route("{username}/{password}")]
        public async Task<IActionResult> Signin(string username, string password)
        {
            try
            {
                Login model = new Login()
                {

                    Username = username,
                    Password = password
                };

                var user = await AuthentificationUser(model.Username, model.Password);
                if (user.Id == 0)
                    return StatusCode((int)HttpStatusCode.NotFound, "Invalid user");
                user.Token = GenerateToken(model);
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("{username}/{password}")]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            try
            {

                Login model = new Login()
                {
                    Username = username,
                    Password = password
                };
                var user = await AuthentificationUser(model.Username, model.Password);
                if (user == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Invalid user");
                user.Token = GenerateToken(model);
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repositoryLogin.GetAll();
            return Ok(users);
        }
        private string GenerateToken(Login model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        private async Task<Login> AuthentificationUser(string username, string password)
        {
            return await _repositoryLogin.GetUsernameAndPassword(username, password);
        }
    }
}
