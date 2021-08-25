using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ADN.Application.Person.Queries
{
    public record PersonQuery([Required] Guid Id) : IRequest<PersonDto>;

}
