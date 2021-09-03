using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using ADN.Domain.Ports;

using AutoMapper;

using MediatR;

namespace ADN.Application.Vehicle.Queries
{
    public class VehiclesQueryHandler :
     IRequestHandler<VehiclesQuery, IEnumerable<VehicleDto>>, IDisposable
    {

        private readonly IGenericRepository<ADN.Domain.Entities.Vehicle> _VehicleRepository;
        private readonly IMapper _mapper;

        public VehiclesQueryHandler(IGenericRepository<ADN.Domain.Entities.Vehicle> vehicleRepository, IMapper mapper)
        {
            _VehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleDto>> Handle(VehiclesQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                var test = await _VehicleRepository.GetAsync(vehicle => vehicle.State == 0);
                return test.Select(y => new VehicleDto { Id = y.Id, Cc = y.Cc, DateOfIn = y.DateOfIn, Plate = y.Plate, State = y.State, Type = y.Type }); 
            }
            catch (Exception x)
            {

                throw new Exception("Error al consultar la base de datos", x);
            }
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