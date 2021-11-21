using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            try
            {
                var result = await _personService.FindAllPeopleAsync();
                var response = new PersonListResponse();
                response.PersonObjects = new List<PersonDto>();
                response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonResponse> FindPersonByIDAsync(int BusinessEntityID)
        {
            try
            {
                var result = await _personService.FindPersonByIDAsync(BusinessEntityID);
                if (result != null)
                {
                    var response = new PersonResponse();
                    response.PersonObject = new PersonDto();
                    response.PersonObject = _mapper.Map<PersonDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonResponse> AddPerson(PersonRequest request)
        {
            try
            {
                Person newPerson = new Person
                {
                    Name = request.Name
                };
                var result = await _personService.AddPerson(newPerson);
                if(result != null)
                {
                    var response = new PersonResponse();
                    response.PersonObject = new PersonDto();
                    response.PersonObject = _mapper.Map<PersonDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonResponse> UpdatePerson(PersonDto request)
        {
            try
            {
                var personPhone = await _personService.FindPersonByIDAsync(request.BusinessEntityID);
                if (personPhone == null) return null;

                _mapper.Map(request, personPhone);

                var result = await _personService.UpdatePerson(personPhone);
                if (result != null)
                {
                    var response = new PersonResponse();
                    response.PersonObject = new PersonDto();
                    response.PersonObject = _mapper.Map<PersonDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletePerson(int BusinessEntityID)
        {
            try
            {
                return await _personService.DeletePerson(BusinessEntityID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
