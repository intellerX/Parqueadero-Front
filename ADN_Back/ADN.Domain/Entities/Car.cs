using System;

namespace ADN.Domain.Entities
{
    public class Car : Vehicle<Guid>
    {
        public string HourValue { get; set; } = default!;
        public string DayValue { get; set; } = default!;

        public Car(string hourValue, string dayValue)
        {
            HourValue = hourValue;
            DayValue = dayValue;
        }
        public Car()
        {

        }
    }
}