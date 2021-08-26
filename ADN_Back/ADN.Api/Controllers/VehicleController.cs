using System;
using System.Threading.Tasks;
using ADN.Application.Vehicle.Command;
using ADN.Application.Vehicle.Queries;
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
    public class VehicleController : ControllerBase
    {

        private readonly IMediator _Mediator;       

        public VehicleController(IMediator mediator)
        {
            _Mediator = mediator;           
        }


        [HttpGet("{id}")]
        public async Task<VehicleDto> GetVehicle(Guid id) => await _Mediator.Send(new VehicleQuery(id));

        [HttpPost]
        public async Task NewVehicle(CreateVehicleCommand person) => await _Mediator.Send(person);

    }
}