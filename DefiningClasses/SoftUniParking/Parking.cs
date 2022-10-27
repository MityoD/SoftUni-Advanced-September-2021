using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Dictionary<string, Car> cars;

        private int capacity;
        public Parking(int capacity)
        {
            cars = new Dictionary<string, Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            string toReturn = "";
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                toReturn = "Car with that registration number, already exists!";
            }
            else if (this.capacity <= cars.Count)
            {
                toReturn = "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                toReturn = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            return toReturn;
        }
        public string RemoveCar(string thisRegistrationNumber)
        {   //Car currentCar = cars.Values.Where(r => r.RegistrationNumber == thisRegistrationNumber).FirstOrDefault();
            if (!cars.Any(r => r.Key == thisRegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(thisRegistrationNumber);
                return  $"Successfully removed {thisRegistrationNumber}";
            }
        }
        public string GetCar(string thisRegistrationNumber) 
        {
            Car currentCar = cars.Values.Where(r => r.RegistrationNumber == thisRegistrationNumber).FirstOrDefault();
            return currentCar.ToString();
        }
        //public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers) 
        //{
        //    foreach (var number in RegistrationNumbers)
        //    {
        //        if (cars.ContainsKey(number))
        //        {
        //            cars.Remove(number);
        //        }
        //    }
        //}

        public int Count => cars.Count;

    }
}
