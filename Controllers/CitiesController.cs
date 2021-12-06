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
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IRepositoryCity _repositoryCity;
        public CitiesController(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;

        }
        [HttpDelete]
        public IActionResult Remove([FromBody] City cities)
        {
            _repositoryCity.Remove(cities);
            return Ok(cities);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cities = _repositoryCity.FindAll();
            return Ok(cities);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] City cities)
        {
            _repositoryCity.Create(cities);
            return Ok(cities);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy([FromBody] City cities)
        {
            _repositoryCity.FindBy(cities);
            return Ok(cities);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromHeader] City cities)
        {
            _repositoryCity.Update(cities);
            return Ok(cities);
        }
    }
}
