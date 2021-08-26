using System;

namespace ADN.Domain.Entities
{
    public class Vehicle : EntityBase<Guid>
    {
        public string Plate { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
        public string Cc { get; set; } = default!;
        public string State { get; set; } = default!;

        public Vehicle(string plate, string dateOfIn, string cc, string state)
        {
            Plate = plate;
            DateOfIn = dateOfIn;
            Cc = cc;
            State = state;
        }
        public Vehicle()
        {

        }
    }
}