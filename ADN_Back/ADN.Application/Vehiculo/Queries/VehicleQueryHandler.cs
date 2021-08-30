using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ADN.Domain.Ports;

using AutoMapper;

using MediatR;

namespace ADN.Application.Vehicle.Queries
{
    public class VehicleQueryHandler :
     IRequestHandler<VehicleQuery, VehicleDto>, IDisposable
    {

        private readonly IGenericRepository<ADN.Domain.Entities.Vehicle> _VehicleRepository;
        private readonly IMapper _mapper;

        public VehicleQueryHandler(IGenericRepository<ADN.Domain.Entities.Vehicle> vehicleRepository, IMapper mapper)
        {
            _VehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleDto> Handle(VehicleQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            return _mapper.Map<VehicleDto>(await _VehicleRepository.GetByIdAsync(request.Id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._VehicleRepository.Dispose();
        }
    }
}