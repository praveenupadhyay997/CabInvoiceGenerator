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
        private readonly RideRepository rideRepository;
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
            this.rideRepository = new RideRepository();
            this.MINIMUM_COST_PER_KM = 10;
            this.COST_PER_KM = 1;
            this.MINIMUM_FARE = 5;
        }
        /// <summary>
        /// Method to Compute the total fare of the cab journey when passed with distance and time
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
                if(rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDETYPE, "Ride Type is Invalid");
                }
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
        /// <summary>
        /// Method to get the Invoice summary when passed with the history of ride taken
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            /// Adding a variable to compute average fare
            double averageFare = 0;
            /// Exception handling for the invalid  distance and time
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
                /// Computing average fare = (total fare/ number of rides)
                averageFare = (totalFare / rides.Length);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
            /// Returning the invoice summary with average fare too
            return new InvoiceSummary(totalFare, rides.Length, averageFare) ;
        }
        /// <summary>
        /// Method to add the Customer info to the ride repository as a dictionary with key as UserID and value as ride history
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="rides"></param>
        public void AddRides(string userID, Ride[] rides)
        {
            /// Exception handling for null rides
            /// While adding the data to the dictionary with use Id and ride history
            try
            {
                /// Calling the Add ride method of Ride Repository class
                rideRepository.AddRide(userID, rides);
            }
            catch(CabInvoiceException)
            {
                /// Returning the custom exception in case the rides are null
                if(rides ==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
                }
            }
        }
        /// <summary>
        /// Method to return the invoice summary when passed with user ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userID)
        {
            /// Handling the exception for the invalid user ID
            /// Returning the Invoice Summary with the attributes of total fare, number of rides and average fare
            try
            {
                double averageFare = (Convert.ToDouble(this.CalculateFare(rideRepository.GetRides(userID)))) / (rideRepository.GetRides(userID).Length);
                return new InvoiceSummary(Convert.ToDouble(this.CalculateFare(rideRepository.GetRides(userID))), rideRepository.GetRides(userID).Length, averageFare);
            }
            /// Catching the custom exception of invalid user id
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "ID passed for User is Invalid");
            }
        }
    }
}
