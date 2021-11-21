
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<PersonPhone> AddPersonPhone(PersonPhone newPersonPhones);
        Task<PersonPhone> UpdatePersonPhone(PersonPhone updatedPersonPhone);
        Task<bool> DeletePersonPhone(int BusinessEntityID, int PhoneNumberTypeID);
        Task<List<PersonPhone>> FindAllPersonPhonesAsync();
        Task<PersonPhone> FindPersonPhoneByIDAsync(int BusinessEntityID, int PhoneNumberTypeID);

    }
}
