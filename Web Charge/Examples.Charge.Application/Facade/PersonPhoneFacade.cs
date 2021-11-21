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
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade (IPersonPhoneService personService, IMapper mapper)
        {
            _personPhoneService = personService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {


            try
            {
                var result = await _personPhoneService.FindAllPersonPhonesAsync();
                if (result != null)
                {
                    var response = new PersonPhoneListResponse();
                    response.PersonPhoneObjects = new List<PersonPhoneDto>();
                    response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        public async Task<PersonPhoneResponse> FindPersonPhoneByIDAsync(PersonPhoneRequest request)
        {
            try
            {
                var result = await _personPhoneService.FindPersonPhoneByIDAsync(request.BusinessEntityID, request.PhoneNumberTypeID);
                if (result != null)
                {
                    var response = new PersonPhoneResponse();
                    response.PersonPhoneObject = new PersonPhoneDto();
                    response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonPhoneResponse> AddPersonPhone(PersonPhoneRequest request)
        {
            try
            {

                PersonPhone newPersonPhone = new PersonPhone
                {
                    BusinessEntityID = request.BusinessEntityID,
                    PhoneNumberTypeID = request.PhoneNumberTypeID,
                    PhoneNumber = request.PhoneNumber, 
                };
                var result = await _personPhoneService.AddPersonPhone(newPersonPhone);
                if (result != null)
                {
                    var response = new PersonPhoneResponse();
                    response.PersonPhoneObject = new PersonPhoneDto();
                    response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonPhoneResponse> UpdatePersonPhone(PersonPhoneDto request)
        {
            try
            {
                var personPhone = await _personPhoneService.FindPersonPhoneByIDAsync(request.BusinessEntityID, request.PhoneNumberTypeID);
                if (personPhone == null) return null;

                _mapper.Map(request, personPhone);

                var result = await _personPhoneService.UpdatePersonPhone(personPhone);
                if (result != null)
                {
                    var response = new PersonPhoneResponse();
                    response.PersonPhoneObject = new PersonPhoneDto();
                    response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePersonPhone(PersonPhoneRequest request)
        {
            try
            {
                return await _personPhoneService.DeletePersonPhone(request.BusinessEntityID, request.PhoneNumberTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
