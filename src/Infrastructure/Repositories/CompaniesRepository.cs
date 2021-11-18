using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CompaniesRepository(
            ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Company>> FindCompany(
            DateTime from,
            DateTime to,
            Province province,
            CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Companies.AsNoTracking().Where(c => c.Province == province && c.Created > from && c.Created < to).ToListAsync(cancellationToken);
        }

        public async Task<int> CreateCompany(
            Company company,
            CancellationToken cancellationToken)
        {
            _applicationDbContext.Companies.Add(company);
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
