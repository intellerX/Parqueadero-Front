using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ADN.Domain.Services;
using MediatR;

namespace ADN.Application.Vehicle.Command
{
    public class CreateVehicleCommandHandler : AsyncRequestHandler<CreateVehicleCommand>
    {
        readonly VehicleService _vehicleService;

        public CreateVehicleCommandHandler(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;

        }

        protected override async Task Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            await _vehicleService.RegisterVehicle(new Domain.Entities.Vehicle
            {
                Plate = request.Plate,
                Cc = request.Cc,
                Type = request.Type,
                State = request.State,
                DateOfIn = request.DateOfIn
            });
        }
    }
}
