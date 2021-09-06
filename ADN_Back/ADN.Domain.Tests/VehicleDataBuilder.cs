using System;
using ADN.Domain.Entities;
using static ADN.Domain.Entities.Vehicle;

namespace ADN.Domain.Tests
{

    public class VehicleDataBuilder
    {
        string Plate;
        int Cc;
        VehicleType Type;
        VehicleState State;
        DateTime DateOfIn;

        public Vehicle Build()
        {
            Vehicle vehicle = new(Plate, Cc, Type, State, DateOfIn);
            vehicle.Id = Guid.NewGuid();
            return vehicle;
        }

        public VehicleDataBuilder WithDateOfIn(DateTime dateOfIn)
        {
            DateOfIn = dateOfIn;
            return this;
        }

        public VehicleDataBuilder WithPlate(string plate)
        {
            Plate = plate;
            return this;
        }

        public VehicleDataBuilder WithCc(int cc)
        {
            Cc = cc;
            return this;
        }

        public VehicleDataBuilder WithType(int type)
        {
            Type = (VehicleType)type;
            return this;
        }
        public VehicleDataBuilder WithState(VehicleState state)
        {
            State = state;
            return this;
        }

        internal VehicleDataBuilder WithType(VehicleType type)
        {
            Type = type;
            return this;
        }
    }
}