using System;
using System.Collections.Generic;
using System.Text;



    public class SubscriptionParkingSpot : ParkingSpot
    {
        private string registrationPlate;

        public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate) : base(id, occupied, "subscription", price)
        {
            RegistrationPlate = registrationPlate;
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

    
    public override bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        //TODO: Implement me
        throw new NotImplementedException();
    }

    public override double CalculateTotal()
    {
        //TODO: Implement me
        throw new NotImplementedException();
    }
    
}

