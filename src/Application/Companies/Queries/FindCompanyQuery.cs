using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Companies.Queries
{
    public class FindCompanyQuery : IRequest<ICollection<Company>>
    {
        public FindCompanyQuery(
           DateTime from,
           DateTime to,
           Province province)
        {
            From = from;
            To = to;
            Province = province;
        }

        public DateTime From { get; }

        public DateTime To { get; }

        public Province Province { get; }
    }

    public class FindCompanyQueryHandler : IRequestHandler<FindCompanyQuery, ICollection<Company>>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public FindCompanyQueryHandler(
            ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<ICollection<Company>> Handle(
            FindCompanyQuery request,
            CancellationToken cancellationToken)
        {
            return await _companiesRepository.FindCompany(request.From, request.To, request.Province, cancellationToken);
        }
    }
}
