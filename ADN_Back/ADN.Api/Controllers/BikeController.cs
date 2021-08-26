using System;
using System.Threading.Tasks;
using ADN.Application.Bike.Command;
using ADN.Application.Bike.Queries;
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
    public class BikeController : ControllerBase
    {

        private readonly IMediator _Mediator;       

        public BikeController(IMediator mediator)
        {
            _Mediator = mediator;           
        }


        [HttpGet("{id}")]
        public async Task<BikeDto> GetBike(Guid id) => await _Mediator.Send(new BikeQuery(id));

        [HttpPost]
        public async Task NewBike(CreateBikeCommand person) => await _Mediator.Send(person);

    }
}