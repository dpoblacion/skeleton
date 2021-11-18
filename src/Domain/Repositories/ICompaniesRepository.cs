using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories
{
    public interface ICompaniesRepository
    {
        Task<List<Company>> FindCompany(
            DateTime from,
            DateTime to,
            Province province,
            CancellationToken cancellationToken);

        Task<int> CreateCompany(
            Company company,
            CancellationToken cancellationToken);
    }
}
