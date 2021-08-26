using System;

namespace ADN.Domain.Entities
{
    public class Bike : Vehicle
    {

        public int HourValue { get; set; } = 500;
        public int DayValue { get; set; } = 4000;
        
        public Bike(string plate, DateTime dateOfIn, string cc, string state ) 
            : base(plate, dateOfIn, cc, state)
        {

        }
        public Bike()
        {

        }

    }
}