using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICommonRepository _commonRepository;

        public PersonService(IPersonRepository personRepository, ICommonRepository commonRepository)
        {
            _personRepository = personRepository;
            _commonRepository = commonRepository;

        }

        public async Task<Person> AddPerson(Person newPerson)
        {
            try
            {

                _commonRepository.Add(newPerson);

                if (await _commonRepository.SaveChangesAsync())
                {
                    var personReturn = await _personRepository.FindByIDAsync(newPerson.BusinessEntityID);

                    return personReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Person>> FindAllPeopleAsync()
        {
            try
            {
                var people = await _personRepository.FindAllAsync();
                if (people == null) return null;

                var result = people.ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Person> FindPersonByIDAsync(int BusinessEntityID)
        {
            try
            {
                var person = await _personRepository.FindByIDAsync(BusinessEntityID);
                if (person == null) return null;

                var result = person;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
