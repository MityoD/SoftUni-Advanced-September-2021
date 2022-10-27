using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {/*	•	Make: string
	•	Model: string
	•	LicensePlate: string
	•	HorsePower: int
	•	Weight: double */
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine($"Make: {Make}");
            print.AppendLine($"Model: {Model}");
            print.AppendLine($"License Plate: {LicensePlate}");
            print.AppendLine($"Horse Power: {HorsePower}");
            print.AppendLine($"Weight: {Weight}");
            return print.ToString().TrimEnd();
        }
        public Car()
        {

        }
    }
}
