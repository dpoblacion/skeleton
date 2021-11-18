using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CreateCompanyCommandHandler(
            ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<int> Handle(
            CreateCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Id = request.Id,
                Name = request.Name,
            };

            return await _companiesRepository.CreateCompany(company, cancellationToken);
        }
    }
}
