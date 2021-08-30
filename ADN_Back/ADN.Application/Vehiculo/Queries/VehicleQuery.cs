using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Vehicle.Queries
{
    public record VehicleQuery([Required] Guid Id) : IRequest<VehicleDto>;

}
