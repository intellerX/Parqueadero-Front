using System;

namespace ADN.Domain.Entities
{
    public abstract class Vehicle : EntityBase<Guid>
    {
        protected string Plate { get; set; } = default!;
        protected DateTime DateOfIn { get; set; } = default!;
        protected string Cc { get; set; } = default!;
        protected string State { get; set; } = default!;

        public Vehicle(string plate, DateTime dateOfIn, string cc, string state)
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