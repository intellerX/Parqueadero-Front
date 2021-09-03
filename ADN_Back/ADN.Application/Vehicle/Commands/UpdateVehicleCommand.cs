using System;
using System.ComponentModel.DataAnnotations;
using ADN.Application.Vehicle.Queries;
using MediatR;
using static ADN.Domain.Entities.Vehicle;

namespace ADN.Application.Vehicle.Command
{
    public record UpdateVehicleCommand(
        [Required] Guid Id
    ) : IRequest<VehicleCostDto>;

}
