// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="Bridgelabz">
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
    /// Class to store a mapped data of the customer id and his ride history
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary storing key as the user Id and the ride list or ride history detail as value
        /// </summary>
        Dictionary<string, List<Ride>> userRides = null;
        /// <summary>
        /// Default constructor Initialising the instance of the User Ride Dictionary
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// Method to add the mapped ride data onto the dictionary
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="rides"></param>
        public void AddRide(string userID, Ride[] rides)
        {
            /// To check the presence of the customer data on basis of his id as the key
            bool rideList = this.userRides.ContainsKey(userID);
            /// Catching the custom exception that the rides being passed is null
            try
            {
                /// Catch exception if the list of ride details is null
                if(!rideList)
                {
                    List<Ride> listOfRides = new List<Ride>();
                    /// Adding the array to the list
                    listOfRides.AddRange(rides);
                    /// Adding to the dictionary with userId as the key and list of rides as the coreesponding value
                    this.userRides.Add(userID, listOfRides);
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides passed are null..");
            }
        }
        /// <summary>
        /// Method to get the details of the ride history for a particular user with key as userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Ride[] GetRides(string userID)
        {
            /// Catching the exception of invalid Id in case the return statement encounter the error
            try
            {
                /// Returning the ride history as array of Ride class type
                return this.userRides[userID].ToArray();
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "ID passed for User is Invalid");
            }
        }
    }
}
