using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ParkingSpot
{
    private int id;
    private bool occupied;
    private string type;
    private double price;
    private List<ParkingInterval> parkingIntervals;
    

    protected ParkingSpot(int id, bool occupied, string type, double price)
    {
        Id = id;
        Occupied = occupied;
        Type = type;
        Price = price;
        parkingIntervals = new List<ParkingInterval>();
    }

    public int Id
    {
        get { return id; }
        private set { id = value; }
    }
    public bool Occupied
    {
        get { return occupied; }
        set { occupied = value; }
    }
    public string Type
    {
        get { return type; }
        private set { type = value; }
    }
    public double Price
    {
        get { return price; }
        protected set 
        {
            if (value <= 0)
            {
                throw new ArgumentException("Parking price cannot be less or equal to 0!");
            }
            price = value;
        }
    }
    public List<ParkingInterval> ParkingIntervals
    {
        get { return parkingIntervals; }
    }


    public virtual bool ParkVehicle(string registrationPlate, int hoursParked, string type)
    {
        if (Occupied==true || !Type.Equals(type))
        {
            return false;
        }
        if (Occupied == false && Type.Equals(type))
        {
            ParkingSpot parkingSpot;
            if (type.Equals("bus"))
            {
                parkingSpot = new BusParkingSpot(id, true, Price);
            }
            else if (type.Equals("car"))
            {
                parkingSpot = new CarParkingSpot(id, true, Price);
            }
            else
            {
                parkingSpot = new SubscriptionParkingSpot(id, true, Price, registrationPlate);
            }
            ParkingInterval parkingInterval = new ParkingInterval(parkingSpot, registrationPlate, hoursParked);
            parkingIntervals.Add(parkingInterval);
        }
        return true;
    }

    public List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
    {
        List<ParkingInterval> pI = new List<ParkingInterval>();

        pI = parkingIntervals.Where(p => p.RegistrationPlate.Equals(registrationPlate)).ToList();
        
        return pI;
    }

    public virtual double CalculateTotal()
    {
        double sum = 0;
        foreach (var item in parkingIntervals)
        {
            sum += item.Revenue;
        }
        return sum;
    }


    public override string ToString()
    {
        return $"> Parking Spot #{Id}\n" +
            $"> Occupied: {Occupied}\n" +
            $"> Type: {Type}\n" +
            $"> Price per hour: {Price:F2} BGN";
    }
}

