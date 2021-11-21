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
                var personPhoneExist = await _personPhoneRepository.FindByIDAsync(newPersonPhone.BusinessEntityID, newPersonPhone.PhoneNumberTypeID);
                if(personPhoneExist != null) throw new Exception("Já existe um telefone do mesmo tipo para essa pessoa.");

                _commonRepository.Add(newPersonPhone);

                if (await _commonRepository.SaveChangesAsync())
                {
                    var personPhoneReturn = await _personPhoneRepository.FindByIDAsync(newPersonPhone.BusinessEntityID, newPersonPhone.PhoneNumberTypeID);

                    return personPhoneReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonPhone> UpdatePersonPhone(PersonPhone updatedPersonPhone)
        {
            try
            {
                var personPhoneExist = await _personPhoneRepository.FindByIDAsync(updatedPersonPhone.BusinessEntityID, updatedPersonPhone.PhoneNumberTypeID);
                if (personPhoneExist == null) throw new Exception("Não existe esse telefone no sistema.");

                _commonRepository.Delete(personPhoneExist);
                _commonRepository.Add(updatedPersonPhone);

                if (await _commonRepository.SaveChangesAsync())
                {
                    var personPhoneReturn = await _personPhoneRepository.FindByIDAsync(updatedPersonPhone.BusinessEntityID, updatedPersonPhone.PhoneNumberTypeID);

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
                var personPhone = await _personPhoneRepository.FindByIDAsync(BusinessEntityID, PhoneNumberTypeID);
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
        
        public async Task<List<PersonPhone>> FindAllByBusinessEntityIDAsync(int BusinessEntityID) 
        {
            try
            {
                var personPhones = await _personPhoneRepository.FindAllByBusinessEntityIDAsync(BusinessEntityID);
                if (personPhones == null) return null;

                var result = personPhones.ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonPhone> FindPersonPhoneByIDAsync(int BusinessEntityID, int PhoneNumberTypeID)
        {
            try
            {
                var personPhone = await _personPhoneRepository.FindByIDAsync(BusinessEntityID, PhoneNumberTypeID);
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
