using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ADN.Application.Vehicle.Command;
using ADN.Application.Vehicle.Queries;
using ADN.Domain.Entities;
using ADN.Domain.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADN.Api.Tests
{
    [TestClass]
    public class VehicleControllerTest
    {
        readonly WebapiAppFactory<Startup> _AppFactory;
        readonly Guid _vehicleId;
        public VehicleControllerTest()
        {
            _AppFactory = new WebapiAppFactory<Startup>();
            _vehicleId = Guid.NewGuid();
            SeedDataBase(_AppFactory.Services);
        }

        void SeedDataBase(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var _vehicleRepository = scope.ServiceProvider
                    .GetRequiredService<IGenericRepository<Vehicle>>();
                _ = _vehicleRepository.AddAsync(new Vehicle
                {
                    Id = _vehicleId,
                    Plate = "XZR93F",
                    Cc = 750,
                    Type = 0,
                    State = 0,
                    DateOfIn = DateTime.Now
                }).Result;
            }
        }

        [TestMethod]
        public async Task FindVehicleSuccess()
        {
            var client = _AppFactory.CreateClient();
            var response = await client.GetAsync($"/api/vehicle/{_vehicleId.ToString()}");
            response.EnsureSuccessStatusCode();
            var vehicle = JsonSerializer
            .Deserialize<VehicleDto>(await response.Content.ReadAsStringAsync(), new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            });
            Assert.IsTrue(vehicle.Plate.Equals("XZR93F"));
        }

        [TestMethod]
        public async Task RegisterVehicleDuplicateFailure()
        {
            HttpResponseMessage response = null;

            try
            {
                var client = _AppFactory.CreateClient();
                var request = new CreateVehicleCommand("XZR93F", 750, 0, 0, DateTime.Now);
                var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                response = await client.PostAsync("/api/vehicle", requestContent);
                response.EnsureSuccessStatusCode();
            }
            catch (System.Exception)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public async Task RegisterVehiclePickAndPlateFailure()
        {
            HttpResponseMessage response = null;

            try
            {
                var client = _AppFactory.CreateClient();
                var request = new CreateVehicleCommand("XZR13F", 750, 0, 0, new DateTime(2021, 09, 06, 22, 35, 5));
                var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                response = await client.PostAsync("/api/vehicle", requestContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

        }




        [TestMethod]
        public async Task RegisterVehiclePlateFailure()
        {
            HttpResponseMessage response = null;
            try
            {
                var client = _AppFactory.CreateClient();
                var request = new CreateVehicleCommand("PZR", 150, 0, 0, DateTime.Now);
                var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                response = await client.PostAsync("/api/vehicle", requestContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

        }

        [TestMethod]
        public async Task RegisterVehicleSuccess()
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateVehicleCommand("PZR93F", 150, 0, 0, new DateTime(2021, 09, 06, 22, 35, 5));
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/vehicle", requestContent);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task ExitVehicleCostSuccess()
        {
            var client = _AppFactory.CreateClient();
            var request = new UpdateVehicleCommand(_vehicleId);
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/vehicle", requestContent);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

    }
}
