using System;
using System.Threading.Tasks;
using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Ports;

namespace ADN.Domain.Services
{
    [DomainService]
    public class VehicleService : IDisposable
    {
        readonly IGenericRepository<Vehicle> _repository;
        public VehicleService(IGenericRepository<Vehicle> repository)
        {
            _repository = repository ?? throw new ArgumentNullException("No vehicle repo available");
        }

        public async Task<Vehicle> RegisterVehicle(Vehicle vehicle){
            
            return await _repository.AddAsync(vehicle);
        }

        public async Task<Vehicle> FindVehicle(Guid id) {
            return await _repository.GetByIdAsync(id);
        }
        
        bool IsPlateRestricted(string Plate){
            return (Plate == "" )? true : false;            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }
    }
}