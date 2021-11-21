using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() {
            IQueryable<Person> query = _context.Person
                                               .Include(person => person.Phones)
                                               .ThenInclude(phone => phone.PhoneNumberType);

            query = query.AsNoTracking().OrderBy(person => person.BusinessEntityID);
            
            return await query.ToArrayAsync();

        }

        public async Task<Person> FindByIDAsync(int BusinessEntityID)
        {
            IQueryable<Person> query = _context.Person
                                               .Include(p => p.Phones)
                                               .ThenInclude(phone => phone.PhoneNumberType);

            query = query.AsNoTracking().OrderBy(person => person.BusinessEntityID)
                         .Where(person => person.BusinessEntityID == BusinessEntityID);

            return await query.FirstOrDefaultAsync();
        }
    }
}
