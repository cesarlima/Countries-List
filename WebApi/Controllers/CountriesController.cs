using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.UseCases.CountriesSearch;
using Domain.UseCases.CountrySearch;
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

                if (response == null)
                    NotFound();

                return Ok(response);
            }
            catch
            {
                // Log e alguma mensagem de erro
                return BadRequest();
            }
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode([FromServices] SearchCountryByAlpha3CodeUseCase useCase, string code)
        {
            try
            {
                var response = await useCase.ExecuteAsync(code);

                if (response == null)
                    NotFound();

                return Ok(response);
            }
            catch 
            {
                // Log e alguma mensagem de erro
                return BadRequest();
            }
        }

        [HttpGet("currency/{currency}")]
        public async Task<IActionResult> GetByCurrency([FromServices] SearchCountryByCurrencyCodeUseCase useCase, string currency)
        {
            try
            {
                var response = await useCase.ExecuteAsync(currency);

                if (response == null)
                    NotFound();

                return Ok(response);
            }
            catch
            {
                // Log e alguma mensagem de erro
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] SearchCountryByIdUseCase useCase, Guid id)
        {
            try
            {
                var response = await useCase.ExecuteAsync(id);

                if (response == null)
                    NotFound();

                return Ok(response);
            }
            catch
            {
                // Log e alguma mensagem de erro
                return BadRequest();
            }
        }
    }
}
