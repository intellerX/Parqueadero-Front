using System;
using System.Threading.Tasks;
using ADN.Application.Car.Command;
using ADN.Application.Car.Queries;
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
    public class CarController : ControllerBase
    {

        private readonly IMediator _Mediator;       

        public CarController(IMediator mediator)
        {
            _Mediator = mediator;           
        }


        [HttpGet("{id}")]
        public async Task<CarDto> GetCar(Guid id) => await _Mediator.Send(new CarQuery(id));

        [HttpPost]
        public async Task NewCar(CreateCarCommand person) => await _Mediator.Send(person);

    }
}