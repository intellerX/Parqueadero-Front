using System;

namespace ADN.Domain.Entities
{
    public class Car : Vehicle
    {

        public int HourValue { get; set; } = 1000;
        public int DayValue { get; set; } = 8000;
        public Car(string plate, DateTime dateOfIn, string cc, string state) 
            : base(plate, dateOfIn, cc, state)
        {

        }

        public Car()
        {

        }

    }
}