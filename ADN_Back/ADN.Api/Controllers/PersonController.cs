using System;
using System.Threading.Tasks;
using ADN.Application.Person.Command;
using ADN.Application.Person.Queries;
using ADN.Domain.Entities;
using ADN.Domain.Ports;
using ADN.Domain.Services;
using ADN.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IMediator _Mediator;       

        public PersonController(IMediator mediator)
        {
            _Mediator = mediator;           
        }


        [HttpGet("{id}")]
        public async Task<PersonDto> GetPerson(Guid id) => await _Mediator.Send(new PersonQuery(id));

        [HttpPost]
        public async Task NewPerson(CreatePersonCommand person) => await _Mediator.Send(person);

    }
}