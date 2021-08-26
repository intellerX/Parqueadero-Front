using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Bike.Command {
    public record CreateBikeCommand(
        [Required, MaxLength(12)] string Plate,
        [Required] DateTime DateOfIn,
        [Required, MaxLength(12)] string Cc,
        [Required, MaxLength(12), EmailAddress] string state
    ) : IRequest;

}