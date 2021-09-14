using System;
using System.Threading.Tasks;
using ADN.Domain.Entities;
using ADN.Domain.Exceptions;
using ADN.Domain.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ADN.Domain.Entities.Vehicle;



namespace ADN.Domain.Services
{
    [DomainService]
    public class VehicleService : IDisposable
    {
        private readonly IGenericRepository<Vehicle> _repository;
        private static int MaxCapBike = 10;
        private static int MaxCapCar = 20;
        private static int CostCarDay = 8000;
        private static int CostCarHour = 1000;
        private static int CostBikeDay = 4000;  
        private static int CostBikeHour = 500;
        private static int CostBigBike = 2000;
        public VehicleService(IGenericRepository<Vehicle> repository)
        {
            _repository = repository ?? throw new ArgumentNullException("No vehicle repo available");
        }

        public async Task<Vehicle> RegisterVehicle(Vehicle vehicle){

            await VehicleValidateInAsync(vehicle.Plate);

            await VehicleSpaceAsync(vehicle.Type);

            if (IsVehiclePlateRestringed( vehicle.Plate, vehicle.DateOfIn))
            {
                throw new VehiclePlateException("Placa invalida o el vehiculo tiene restriccion de pico y placa");
            }
            return await _repository.AddAsync(vehicle);
        }

              


        public async Task<int> UpdateStatusVehicle(Vehicle vehicle)
        {
            var vehicle_exist = await _repository.GetByIdAsync(vehicle.Id);
            vehicle_exist.State = VehicleState.Inactivo;
            await _repository.UpdateAsync(vehicle_exist);
            var total_cost = VehicleTotalPrice(vehicle_exist);
            return (total_cost);
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

        int VehicleTotalPrice(Vehicle vehicle)
        {
            var hours = Math.Ceiling((DateTime.Now - vehicle.DateOfIn).TotalHours);
            var totalCost = 0;

            // suma los dias
            while (hours >= 9)
            {
                if (vehicle.Type == VehicleType.Moto)
                    totalCost += CostBikeDay;
                else
                    totalCost += CostCarDay;
                hours -= 24;
            }

            if (hours < 0)
                hours = 0;

            // suma las horas y cobra sobrecargo para motos mayores a 500CC
            if (vehicle.Type == VehicleType.Moto)
            {
                totalCost += Convert.ToInt32(hours * CostBikeHour);
                if (vehicle.Cc >= 500)
                {
                    totalCost += CostBigBike;
                }
            }
            else
                totalCost += Convert.ToInt32(hours * CostCarHour);

            return totalCost;
        }

        public async Task VehicleSpaceAsync(VehicleType type)
        {
            if (type == VehicleType.Moto)
            {
                var bike_count = await _repository.GetAsync(bike => bike.Type == (VehicleType.Moto));
                if (bike_count.Count() >= MaxCapBike)
                    throw new VehicleExistException("El parqueadero ya esta en su limite de motos");
            }
            else
            {
                var car_count = _repository.GetAsync(car => car.Type == (VehicleType.Carro));
                if (car_count.Result.Count() >= MaxCapCar)
                    throw new VehicleExistException("El parqueadero ya esta en su limite de carros");
            }

        }

        public async Task VehicleValidateInAsync(string plate)
        {
            var vehicle_exist = await _repository.GetAsync(v => (v.Plate == plate) && (v.State == VehicleState.Activo));
            if (vehicle_exist.Count() != 0)
                throw new VehicleExistException("El Vehiculo ya se encuentra en el parqueadero");

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