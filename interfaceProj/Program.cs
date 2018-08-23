using System;
using System.Collections.Generic;

namespace interfaceProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("sdfg233",25);
            HotelRoom myHotel = new HotelRoom("101",350);
            Console.Write("How many days would you like to rent my car?");
            int daysToRent = Int32.Parse(Console.ReadLine());
            Console.WriteLine("The rent for my car is $50 an hour for {0} of days is ${1} ", daysToRent, myCar.rent(daysToRent));  

            Console.Write("How many nights would you like to stay?");
            int nightsToRent = Int32.Parse(Console.ReadLine());
            Console.WriteLine("The rent per night is $350 for {0} days is ${1} ", nightsToRent, myHotel.rent(daysToRent));  
            
            List<IRentable> rentableThings = new List<IRentable>();
            rentableThings.Add(myCar);
            rentableThings.Add(myHotel);
            foreach(IRentable thing in rentableThings)
            {
                if(thing is Car)
                {
                    Car temp = (Car)thing;
                    Console.WriteLine("To rent my car for one day it is $ {0}.",temp.rent(1));
                    Console.WriteLine("The deposit to rent the car for this amount of time is $ {0}", temp.deposit(1));
                    
                }
                if(thing is HotelRoom)
                {
                    Console.WriteLine("for one day of rent $ {0}",thing.rent(1));
                    Console.WriteLine("The Deposit for the hotel room is $ {0}", thing.deposit(1));
                }
            }
        }
        class Car : IRentable
        {
            public string licenseNo{get; private set;}				
            public double hourlyRate {get; private set;}
            public Car(string licenseNo, double hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                this.licenseNo = licenseNo;
            }
            public double rent(double days)
            {
                return hourlyRate * (days*24);
            }
            public double deposit(double days)
            {
                return (hourlyRate * (days*24))*.1;
            }
        }
        class HotelRoom : IRentable
        {
            public string roomNo {get; private set;}
            public double nightlyRate {get; private set;}
            public HotelRoom(string roomNo, double nightlyRate)
            {
                this.nightlyRate = nightlyRate;
                this.roomNo = roomNo;
            }
            public double rent(double days)
            {
                return nightlyRate * days;
            }
            public double deposit(double days)
            {
                return (nightlyRate * days)*.1;
            }

        }
        public interface IRentable
        {
            double rent(double days);
            double deposit(double days);
        }
    }
}
