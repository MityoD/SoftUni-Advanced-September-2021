using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double  FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public void DriveCar(double distanceToDrive)
        {
            double fuelLeft = FuelAmount - (distanceToDrive * FuelConsumptionPerKilometer);
            if (fuelLeft >= 0)
            {               
                FuelAmount -= distanceToDrive * FuelConsumptionPerKilometer;
                TravelledDistance += distanceToDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
