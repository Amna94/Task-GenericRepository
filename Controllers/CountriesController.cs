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
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IRepositoryCountry _countryRepository;
        public CountriesController(IRepositoryCountry countryRepository)
        {
            _countryRepository = countryRepository;

        }

        [HttpPost]
        public IActionResult Create([FromBody] Country countries)
        {
            _countryRepository.Create(countries);
            return Ok(countries);
        }
        [HttpDelete]
        public IActionResult Remove([FromBody] Country countries)
        {

            _countryRepository.Remove(countries);
            return Ok(countries);
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var countries = _countryRepository.FindAll();
            return Ok(countries);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Country countries)
        {
            _countryRepository.Update(countries);
            return Ok(countries);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindBy([FromHeader] Country countries)
        {
            _countryRepository.FindBy(countries);
            return Ok(countries);
        }
    }
}
