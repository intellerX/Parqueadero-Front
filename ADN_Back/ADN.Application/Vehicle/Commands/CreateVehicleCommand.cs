using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using static ADN.Domain.Entities.Vehicle;

namespace ADN.Application.Vehicle.Command {
    public record CreateVehicleCommand(
        [Required, MaxLength(64)] string Plate,
        [Required] int Cc,
        [Required] VehicleType Type,
        [Required] VehicleState State,
        [Required] DateTime DateOfIn
    ) : IRequest;

}