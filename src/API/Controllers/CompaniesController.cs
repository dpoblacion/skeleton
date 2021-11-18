using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Companies.Commands;
using Application.Companies.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ICollection<Company>> Find(
            [FromQuery] FindCompanyQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> Create(
            CreateCompanyCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
