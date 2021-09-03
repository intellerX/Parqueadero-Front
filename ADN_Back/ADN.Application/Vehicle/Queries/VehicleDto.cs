using System;
using static ADN.Domain.Entities.Vehicle;

namespace ADN.Application.Vehicle.Queries
{
    public class VehicleDto
    {
        public VehicleDto()
        {
            
        }
        public Guid Id { get; set; }
        public string Plate { get; set; } = default!;
        public int Cc { get; set; } = default!;
        public VehicleType Type { get; set; } = default!;
        public VehicleState State { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
    }
}