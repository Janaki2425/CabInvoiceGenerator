using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;
        private double Minimum_Cost_per_km;
        private int Cost_per_time;
        private double Minimum_fare;
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.Minimum_Cost_per_km = 15;
                    this.Cost_per_time = 2;
                    this.Minimum_fare = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.Minimum_Cost_per_km = 10;
                    this.Cost_per_time = 1;
                    this.Minimum_fare = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_ride_type, "Invalid ride");
            }
        }
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * Minimum_Cost_per_km * Cost_per_time;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_ride_type, "Invalid ride");

                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_distance, "Invalid distance");

                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_time, "Invalid time");

                }
            }
            return Math.Max(totalFare, Minimum_fare);

        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_rides, "rides are null");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}
            

        

        
    

