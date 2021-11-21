using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Application.Messages.Request;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Examples.Charge.Application.Dtos;

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
        public async Task<IActionResult> Post([FromBody] PersonRequest request)
        {
            try
            {
                var person = await _facade.AddPerson(request);
                if (person == null) return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar pessoa. Erro: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonDto request)
        {
            try
            {
                var person = await _facade.UpdatePerson(request);
                if (person == null) return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar telefone. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var phoneResponse = await _facade.FindPersonByIDAsync(id);
                if (phoneResponse == null) return NoContent();

                if (await _facade.DeletePerson(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar deletar pessoa.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar pessoa. Erro: {ex.Message}");
            }
        }

    }
}
