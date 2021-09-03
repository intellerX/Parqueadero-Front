using System;
using static ADN.Domain.Entities.Vehicle;

namespace ADN.Application.Vehicle.Queries
{
    public class VehicleCostDto
    {
        public VehicleCostDto()
        {
            
        }
        public int  Cost { get; set; } = default!;
    }
}