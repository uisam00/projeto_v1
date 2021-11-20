using AutoMapper;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly ICommonRepository _commonRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository,
                                  ICommonRepository commonRepository)
        {
            _personPhoneRepository = personPhoneRepository;
            _commonRepository = commonRepository;
        }

        public async Task<PersonPhone> AddPersonPhone(PersonPhone newPersonPhone)
        {
            try
            {

                _commonRepository.Add(newPersonPhone);

                if (await _commonRepository.SaveChangesAsync())
                {
                    var personPhoneReturn = await _personPhoneRepository.FindByIdAsync(newPersonPhone.BusinessEntityID, newPersonPhone.PhoneNumberTypeID);

                    return personPhoneReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonPhone> UpdatePersonPhone(int BusinessEntityID, int PhoneNumberTypeID, PersonPhone updatedPersonPhone)
        {
            try
            {

                _commonRepository.Update(updatedPersonPhone);

                if (await _commonRepository.SaveChangesAsync())
                {
                    var personPhoneReturn = await _personPhoneRepository.FindByIdAsync(updatedPersonPhone.BusinessEntityID, updatedPersonPhone.PhoneNumberTypeID);

                    return personPhoneReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePersonPhone(int BusinessEntityID, int PhoneNumberTypeID)
        {
            try
            {
                var personPhone = await _personPhoneRepository.FindByIdAsync(BusinessEntityID, PhoneNumberTypeID);
                if (personPhone == null) throw new Exception("Não foi possível encontrar o telefone.");

                _commonRepository.Delete(personPhone);
                return await _commonRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PersonPhone>> FindAllPersonPhonesAsync() 
        {
            try
            {
                var personPhones = await _personPhoneRepository.FindAllAsync();
                if (personPhones == null) return null;

                var result = personPhones.ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonPhone> FindPersonPhoneByIdAsync(int BusinessEntityID, int PhoneNumberTypeID)
        {
            try
            {
                var personPhone = await _personPhoneRepository.FindByIdAsync(BusinessEntityID, PhoneNumberTypeID);
                if (personPhone == null) return null;

                var result = personPhone;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
