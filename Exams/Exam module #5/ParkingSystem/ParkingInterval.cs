using System;
using System.Collections.Generic;
using System.Text;


    public class ParkingInterval
    {
        private ParkingSpot parkingSpot;
        private string registrationPlate;
        private int hoursParked;
        private double revenue;

        public ParkingInterval(ParkingSpot parkingSpot, string registrationPlate, int hoursParked)
        {
            ParkingSpot = parkingSpot;
            RegistrationPlate = registrationPlate;
            HoursParked = hoursParked;
            if (ParkingSpot.Type.Equals("subscription"))
            {
                Revenue = 0;
            }
            else
            {
                Revenue = HoursParked * ParkingSpot.Price;
            }
            
            
        }

        public ParkingSpot ParkingSpot
        {
            get { return parkingSpot; }
            private set { parkingSpot = value; }
        }
        public string RegistrationPlate
        {
            get { return registrationPlate; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Registration plate can’t be null or empty!");
                }
                registrationPlate = value;
            }
        }
        public int HoursParked
        {
            get { return hoursParked; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours parked can’t be zero or negative!");
                }
                hoursParked = value; 
            }
        }
        public double Revenue
        {
            get { return revenue; }
            set { revenue = value; }
        }


        public override string ToString()
        {
            return $"> Parking Spot #{ParkingSpot.Id}\n" +
                $"> RegistrationPlate: {RegistrationPlate}\n" +
                $"> HoursParked: {HoursParked}\n" +
                $"> Revenue: {Revenue:F2} BGN";
        }
    }

