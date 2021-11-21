
using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _facade;
        private IMapper _mapper;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade facade, IMapper mapper)
        {
            _facade = facade;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeListResponse>> Get()
        {
            try
            {
                var types = await _facade.FindAllAsync();
                if (types == null) return NoContent();

                return Ok(types);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }
    }
}
