// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceClass
{
    /// <summary>
    /// Class defined to compute the total fare when the user passes the distance and time of the fare
    /// Also the ride Type is passed to incorporate the future ride type differentiation
    /// </summary>
    public class InvoiceGenerator
    {
        /// <summary>
        /// Declaring the object of the class RideType so as to differentiate the data attributes as time and distance
        /// </summary>
        public RideType rideType;
        /// <summary>
        /// Read-Only attributes acting as constant variable
        /// to be initialised at run time using a parameterised constructor
        /// </summary>
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_KM;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// Default constructor of the Invoice Generator Class
        /// </summary>
        public InvoiceGenerator()
        {

        }
        /// <summary>
        /// PArameterised constructor of the Invoice Generator Class
        /// </summary>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;

            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_KM = 1;
            this.MINIMUM_FARE = 5;
        }
        /// <summary>
        /// Method to Compute the total fare of the cab journey when passed eith distance and time
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            /// Exception handling for the invalid  distance and time
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_KM;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            /// Exception handling for the invalid  distance and time
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
            return new InvoiceSummary(totalFare, rides.Length);
        }
    }

}
