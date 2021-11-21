using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;
        private IMapper _mapper;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get()
        {
            try
            {
                var people = await _facade.FindAllAsync();
                if (people == null) return NoContent();

                return Ok(people);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar telefone. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<PersonPhoneListResponse>> GetById(int id)
        {
            try
            {
                var person = await _facade.FindAllByBusinessEntityIDAsync(id);
                if (person == null) return NoContent();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar telefone. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonPhoneRequest request)
        {
            try
            {
                var personPhone = await _facade.AddPersonPhone(request);
                if (personPhone == null) return NoContent();

                return Ok(personPhone);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar telefone. Erro: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonPhoneDto request)
        {
            try
            {
                var personPhone = await _facade.UpdatePersonPhone(request);
                if (personPhone == null) return NoContent();

                return Ok(personPhone);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar telefone. Erro: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PersonPhoneRequest request)
        {
            try
            {
                var phoneResponse = await _facade.FindPersonPhoneByIDAsync(request);
                if (phoneResponse == null) return NoContent();

                if (await _facade.DeletePersonPhone(request))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar deletar Telefone.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar telefone. Erro: {ex.Message}");
            }
        }

    }

}
