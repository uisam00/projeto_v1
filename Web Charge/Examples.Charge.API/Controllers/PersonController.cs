using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Application.Messages.Request;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;
        private IMapper _mapper;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() {
            try
            {
                var people = await _facade.FindAllAsync();
                if (people == null) return NoContent();

                return Ok(people);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonRequest reuest)
        {
            try
            {
                var person = await _facade.AddPerson(reuest);
                if (person == null) return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pessoa. Erro: {ex.Message}");
            }
        }

    }
}
