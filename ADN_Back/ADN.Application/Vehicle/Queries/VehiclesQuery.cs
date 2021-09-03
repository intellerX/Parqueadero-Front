using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Vehicle.Queries
{
    public record VehiclesQuery() : IRequest<IEnumerable<VehicleDto>>;
}
