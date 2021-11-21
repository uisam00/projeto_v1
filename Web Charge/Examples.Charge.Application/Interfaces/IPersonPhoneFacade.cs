using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindPersonPhoneByIDAsync(PersonPhoneRequest request);
        Task<PersonPhoneResponse> AddPersonPhone(PersonPhoneRequest request);
        Task<PersonPhoneResponse> UpdatePersonPhone(PersonPhoneDto request);
        Task<bool> DeletePersonPhone(PersonPhoneRequest request);
        Task<PersonPhoneListResponse> FindAllByBusinessEntityIDAsync(int BusinessEntityID);
    }
}
