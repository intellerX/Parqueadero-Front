using System;

namespace ADN.Domain.Entities
{
    public class Vehicle : EntityBase<Guid>
    {
        public string Plate { get; set; } = default!;
        public int Cc { get; set; } = default!;
        public VehicleType Type { get; set; } = default!;
        public VehicleState State { get; set; } = default!;
        public DateTime DateOfIn { get; set; } = default!;
        public DateTime UpdatedOn { get; set; } = default!;


        public Vehicle(string plate, int cc, VehicleType type, VehicleState state, DateTime dateOfIn)
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


        public enum VehicleType { Moto , Carro}
        public enum VehicleState { Activo, Inactivo}
    }
}