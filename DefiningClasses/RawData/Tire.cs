using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            List<Tire> tires = new List<Tire>();
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }

        public double Pressure { get; set; }
    }
}
