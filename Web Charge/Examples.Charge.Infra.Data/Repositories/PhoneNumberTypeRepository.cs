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
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly ExampleContext _context;

        public PhoneNumberTypeRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllAsync()
        {
            IQueryable<PhoneNumberType> query = _context.PhoneNumberType;

            query = query.AsNoTracking().OrderBy(type => type.PhoneNumberTypeID);

            return await query.ToArrayAsync();

        }

        public async Task<PhoneNumberType> FindByIDAsync(int PhoneNumberTypeID)
        {
            IQueryable<PhoneNumberType> query = _context.PhoneNumberType;

            query = query.AsNoTracking().OrderBy(type => type.PhoneNumberTypeID)
                         .Where(type => type.PhoneNumberTypeID == PhoneNumberTypeID);

            return await query.FirstOrDefaultAsync();
        }
    }
}
