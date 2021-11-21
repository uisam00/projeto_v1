using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> AddPerson(PersonRequest reuest);
        Task<PersonResponse> UpdatePerson(PersonDto request);
        Task<bool> DeletePerson(int BusinessEntityID);
        Task<PersonResponse> FindPersonByIDAsync(int BusinessEntityID);

    }
}