using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.UseCases.CountriesSearch;
using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName([FromServices] SearchCountryByNameUseCase useCase, string name)
        {
            try
            {
                var response = await useCase.ExecuteAsync(name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
