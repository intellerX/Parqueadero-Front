using System;
using System.Threading.Tasks;
using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADN.Domain.Services
{
    [DomainService]
    public class VehicleService : IDisposable
    {
        private readonly IGenericRepository<Vehicle> _repository;
        private static int MaxCapBike = 10;
        private static int MaxCapCar = 20;
        public VehicleService(IGenericRepository<Vehicle> repository)
        {
            _repository = repository ?? throw new ArgumentNullException("No vehicle repo available");
        }

        public async Task<Vehicle> RegisterVehicle(Vehicle vehicle){

            var vehicle_exist = await _repository.GetAsync(v => (v.Plate == vehicle.Plate) && (v.State == 0));
            if (vehicle_exist.Count() != 0 )
                throw new VehicleExistException("El Vehiculo ya se encuentra en el parqueadero");

            if (IsVehiclePlateRestringed( vehicle.Plate, vehicle.DateOfIn))
            {
                throw new VehiclePlateException("Placa invalida o el vehiculo tiene restriccion de pico y placa");
            }
            return await _repository.AddAsync(vehicle);
        }



        public async Task<Vehicle> FindVehicle(Guid id) {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> AllVehicle()
        {
            return await _repository.GetAsync();
        }

        public async Task<int> UpdateStatusVehicle(Vehicle vehicle)
        {
            var vehicle_exist = await _repository.GetByIdAsync(vehicle.Id);
            vehicle_exist.State = (Vehicle.VehicleState)1;
            await _repository.UpdateAsync(vehicle_exist);
            var total_cost = VehicleTotalPriceAsync(vehicle_exist);
            return await (total_cost);
        }
        
        bool IsVehiclePlateRestringed(string plate, DateTime dateOfIn)
        {
            if (plate.Length > 5)
            {
                if (dateOfIn.DayOfWeek == DayOfWeek.Monday && (plate[3] == '0' || plate[3] == '1'))
                    return true;

                else if (dateOfIn.DayOfWeek == DayOfWeek.Tuesday && (plate[3] == '2' || plate[3] == '3'))
                    return true;

                else if (dateOfIn.DayOfWeek == DayOfWeek.Wednesday && (plate[3] == '4' || plate[3] == '5'))
                    return true;

                else if (dateOfIn.DayOfWeek == DayOfWeek.Thursday && (plate[3] == '6' || plate[3] == '7'))
                    return true;

                else if (dateOfIn.DayOfWeek == DayOfWeek.Friday && (plate[3] == '8' || plate[3] == '9'))
                    return true;

                return false;
            }
            return true;
        }

        async Task<int> VehicleTotalPriceAsync(Vehicle vehicle)
        {
            //var vehicle_exist = await _repository.GetAsync(v => (v.Plate == vehicle.Plate) && (v.State == 0));
            //if (vehicle_exist.Count() == 0)
            //    throw new VehicleExistException("El Vehiculo no se encuentra en el parqueadero");
            // Valida si es Moto
            var hours = (DateTime.Now - vehicle.DateOfIn).TotalHours;
            var totalCost = 0;

            // suma los dias
            while (hours <= 9)
            {
                if (vehicle.Type == 0)
                    totalCost += 4000;  
                else                 
                    totalCost += 8000;                
                hours -= 9;
            }

            // suma las horas y cobra sobrecargo para motos mayores a 500CC
            if (vehicle.Type == 0)
            {
                totalCost = Convert.ToInt32(Math.Ceiling(hours) * 500);
                if (Convert.ToInt32(vehicle.Cc) >= 500)
                {
                    totalCost += 2000;
                }
            }
            else
                totalCost = Convert.ToInt32(Math.Ceiling(hours) * 1000);

            return totalCost;
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