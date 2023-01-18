using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class ParkingController
{
    private List<ParkingSpot> parkingSpots;

    public ParkingController()
    {
        parkingSpots = new List<ParkingSpot>();
    }

    public string CreateParkingSpot(List<string> args)
    {
        int id = int.Parse(args[0]);
        bool occupied = bool.Parse(args[1]);
        string type = args[2];
        double price = double.Parse(args[3]);
        string registrationPlate = "";
        if (type.Equals("subscription"))
        {
            registrationPlate = args[4];
        }

        if (!(type.Equals("bus") || type.Equals("car") || type.Equals("subscription")))
        {
            return "Unable to create parking spot!";
        }

        ParkingSpot parkingSpot;
        if (type.Equals("bus"))
        {
            parkingSpot = new BusParkingSpot(id, occupied, price);
        }
        else if (type.Equals("car"))
        {
            parkingSpot = new CarParkingSpot(id, occupied, price);
        }
        else
        {
            parkingSpot = new SubscriptionParkingSpot(id, occupied, price, registrationPlate);
        }


        foreach (var item in parkingSpots)
        {
            if (item.Id == parkingSpot.Id)
            {
                return $"Parking spot {id} is already registered!";
            }
        }

        parkingSpots.Add(parkingSpot);
        return $"Parking spot {parkingSpot.Id} was successfully registered in the system!";
    }

    public string ParkVehicle(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        string registrationPlate = args[1];
        int hoursParked = int.Parse(args[2]);
        string type = args[3];

        ParkingInterval parkingInterval;
        ParkingSpot pS = parkingSpots.FirstOrDefault(p => p.Id == parkingSpotId);
        if (pS == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        if (pS.Occupied == true || !pS.Type.Equals(type))
        {
            return $"Vehicle {registrationPlate} can't park at {parkingSpotId}.";
        }

        pS.Occupied = true;
        parkingInterval = new ParkingInterval(pS, registrationPlate, hoursParked);
        pS.ParkingIntervals.Add(parkingInterval);
        return $"Vehicle {registrationPlate} parked at {parkingSpotId} for {hoursParked} hours.";
    }

    public string FreeParkingSpot(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        ParkingSpot pS = parkingSpots.FirstOrDefault(p => p.Id==parkingSpotId);
        if (pS==null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        if (pS.Occupied==false)
        {
            return $"Parking spot {parkingSpotId} is not occupied.";
        }

        pS.Occupied = false;
        return $"Parking spot {parkingSpotId} is now free!";
    }

    public string GetParkingSpotById(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);

        ParkingSpot pS = parkingSpots.FirstOrDefault(p => p.Id == parkingSpotId);
        if (pS==null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        return pS.ToString();
    }

    public string GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(List<string> args)
    {
        int parkingSpotId = int.Parse(args[0]);
        string registrationPlate = args[1];

        ParkingSpot pS = parkingSpots.FirstOrDefault(p => p.Id == parkingSpotId);
        if (pS == null)
        {
            return $"Parking spot {parkingSpotId} not found!";
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Parking intervals for parking spot {parkingSpotId}:");
        List<ParkingInterval> search = pS.GetAllParkingIntervalsByRegistrationPlate(registrationPlate);
        foreach (var item in search)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().TrimEnd();
    }

    public string CalculateTotal(List<string> args)
    {
        double sum = 0;

        foreach (var item in parkingSpots)
        {
            sum += item.CalculateTotal();
        }

        return $"Total revenue from the parking: {sum:F2} BGN";
    }

}

