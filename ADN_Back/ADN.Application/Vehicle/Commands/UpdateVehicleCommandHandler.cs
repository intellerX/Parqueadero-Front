using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ADN.Domain.Services;

using MediatR;
using ADN.Application.Vehicle.Queries;

namespace ADN.Application.Vehicle.Command
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand , VehicleCostDto>
    {
        readonly VehicleService _vehicleService;

        public UpdateVehicleCommandHandler(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;

        }

        public async Task<VehicleCostDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var  VehicleCost = await _vehicleService.UpdateStatusVehicle(new Domain.Entities.Vehicle
            {
                Id = request.Id              
            });
            return new VehicleCostDto { Cost = VehicleCost };

        }
    }
}
