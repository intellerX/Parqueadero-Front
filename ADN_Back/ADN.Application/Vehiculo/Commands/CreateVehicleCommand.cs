using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Vehicle.Command {
    public record CreatePersonCommand(
        [Required, MaxLength(64)] string Plate,
        [Required, MaxLength(64)] string Cc,
        [Required, MaxLength(64)] string Type,
        [Required, MaxLength(64)] string State,
        [Required] DateTime DateOfIn
    ) : IRequest;

}