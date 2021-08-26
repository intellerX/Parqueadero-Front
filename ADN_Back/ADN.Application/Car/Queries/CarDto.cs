using System;

namespace ADN.Application.Car.Queries
{
    public class CarDto
    {
        public CarDto()
        {
            
        }
        public Guid Id { get; set; }
        public string Plate { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
        public string Cc { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}