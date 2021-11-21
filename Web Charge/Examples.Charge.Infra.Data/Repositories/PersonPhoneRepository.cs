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
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
        {
            IQueryable<PersonPhone> query = _context.PersonPhone
                                                    .Include(phone => phone.Person)
                                                    .Include(phone => phone.PhoneNumberType);

            query = query.AsNoTracking().OrderBy(phone => phone.BusinessEntityID);

            return await query.ToArrayAsync();

        }

        public async Task<PersonPhone> FindByIDAsync(int BusinessEntityID, int PhoneNumberTypeID)
        {
            IQueryable<PersonPhone> query = _context.PersonPhone
                                                    .Include(phone => phone.Person)
                                                    .Include(phone => phone.PhoneNumberType);

            query = query.AsNoTracking().OrderBy(phone => phone.BusinessEntityID)
                         .Where(phone => phone.BusinessEntityID == BusinessEntityID && phone.PhoneNumberTypeID == PhoneNumberTypeID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PersonPhone>> FindAllByBusinessEntityIDAsync(int BusinessEntityID)
        {
            IQueryable<PersonPhone> query = _context.PersonPhone
                                                    .Include(phone => phone.Person)
                                                    .Include(phone => phone.PhoneNumberType);

            query = query.AsNoTracking().OrderBy(phone => phone.BusinessEntityID)
             .Where(phone => phone.BusinessEntityID == BusinessEntityID );

            return await query.ToArrayAsync();

        }
    }
}
