using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADN.Domain.Ports;
using ADN.Domain.Entities;
using NSubstitute;
using ADN.Domain.Services;
using System.Threading.Tasks;
using ADN.Domain.Exceptions;

namespace ADN.Domain.Tests
{
    [TestClass]
    public class VehicleServiceTest
    {

        IGenericRepository<Vehicle> _vehicleRepository;
        VehicleService _vehicleService;

        [TestInitialize]
        public void Init()
        {
            _vehicleRepository = Substitute.For<IGenericRepository<Vehicle>>();
            _vehicleService = new VehicleService(_vehicleRepository);
        }

        [TestMethod, ExpectedException(typeof(VehiclePlateException))]
        public async Task FailToRegisterPlateVehicle()
        {
            Vehicle new_vehicle = new()
            {
                Plate = "R",
                Cc = 160,
                Type = 0,
                State = 0,
                DateOfIn = System.DateTime.Now
            };

            await _vehicleService.RegisterVehicle(new_vehicle);
        }

        [TestMethod]
        public async Task SuccessToRegisterVehicle()
        {
            Vehicle vehicle_exist = new()
            {
                Plate = "RPJ235",
                Cc = 160,
                Type = 0,
                State = 0,
                DateOfIn = new DateTime(2021, 09, 05, 22, 35, 5)
            };

            _vehicleRepository.AddAsync(Arg.Any<Vehicle>()).Returns(Task.FromResult(
                new VehicleDataBuilder()
                .WithType(vehicle_exist.Type)
                .WithDateOfIn(vehicle_exist.DateOfIn)
                .WithPlate(vehicle_exist.Plate)
                .WithState(vehicle_exist.State)
                .Build()
            ));

            var result = await _vehicleService.RegisterVehicle(vehicle_exist);

            Assert.IsTrue(result is Vehicle && result?.Id is not null);
        }
    }
}
