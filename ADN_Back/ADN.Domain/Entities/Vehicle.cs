using System;

namespace ADN.Domain.Entities
{
    public class Vehicle : EntityBase<Guid>
    {
        public string Plate { get; set; } = default!;
        public string Cc { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string State { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;

        public Vehicle(string plate, string cc, string type, string state, DateTime dateOfIn)
        {
            Plate = plate;
            Cc = cc;
            Type = type;
            State = state;
            DateOfIn = dateOfIn;
        }
        public Vehicle()
        {

        }
    }
}