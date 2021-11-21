using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<Person> AddPerson(Person newPerson);
        Task<Person> UpdatePerson(Person updatedPerson);
        Task<bool> DeletePerson(int BusinessEntityID);
        Task<List<Person>> FindAllPeopleAsync();
        Task<Person> FindPersonByIDAsync(int BusinessEntityID);
    }
}
