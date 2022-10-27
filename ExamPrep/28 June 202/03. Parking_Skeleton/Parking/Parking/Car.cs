using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        public Car(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{this.Manufacturer} {this.Model} ({this.Year})";

        }
        /*	•	Manufacturer: string
	•	Model: string
	•	Year: int
The class constructor should receive manufacturer, model and year and override the ToString() method in the following format:
*/
    }
}
