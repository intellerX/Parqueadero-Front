using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Car.Command {
    public record CreateCarCommand(
        [Required, MaxLength(12)] string Plate,
        [Required] DateTime DateOfIn,
        [Required, MaxLength(12)] string Cc,
        [Required, MaxLength(12), EmailAddress] string state
    ) : IRequest;

}