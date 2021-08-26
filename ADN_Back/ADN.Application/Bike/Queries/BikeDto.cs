using System;

namespace ADN.Application.Bike.Queries
{
    public class BikeDto
    {
        public BikeDto()
        {
            
        }
        public Guid Id { get; set; }
        public string Plate { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
        public string Cc { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}