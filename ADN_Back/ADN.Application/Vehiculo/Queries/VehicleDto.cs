using System;

namespace ADN.Application.Vehicle.Queries
{
    public class VehicleDto
    {
        public VehicleDto()
        {
            
        }
        public Guid Id { get; set; }
        public string Plate { get; set; } = default!;
        public string Cc { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string State { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
    }
}