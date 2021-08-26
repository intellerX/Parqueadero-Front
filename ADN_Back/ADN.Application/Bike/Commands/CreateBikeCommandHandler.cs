using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ADN.Domain.Services;
using MediatR;

namespace ADN.Application.Bike.Command
{
    public class CreateBikeCommandHandler : AsyncRequestHandler<CreateBikeCommand>
    {
        readonly BikeService _personService;

        public CreateBikeCommandHandler(BikeService personService)
        {
            _personService = personService;

        }

        protected override async Task Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            await _personService.RegisterBike(new Domain.Entities.Bike
            {
                Plate = request.Plate,
                DateOfIn = request.DateOfIn,
                Cc = request.Cc,
                State = request.State,
            });
        }
    }
}
