// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using CabInvoiceClass;

namespace NUnitTestProjectForCabInvoiceGenerator
{
    public class Tests
    {
        /// <summary>
        /// Initialising the instance of the Invoice generator class and assigning a null value to its reference
        /// </summary>
        public InvoiceGenerator invoiceGenerator = null;
        /// <summary>
        /// TC 1- Given the distance and time returning the total fare by computing through the calculate fare method
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ReturnsTotalFare()
        {
            double distance = 5.0;
            int time = 5;
            /// Instantinating the object with normal ride type
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            /// Invoking the Calculate Fare method to get the total actual fare
            double totalActualFare = invoiceGenerator.CalculateFare(distance, time);
            double totalExpectedFare = 55.0;
            /// Asserting with the expected value
            Assert.AreEqual(totalExpectedFare, totalActualFare);
        }
        /// <summary>
        /// TC 2, 3- Given the distance and length of multiple rides and then get the summary object of invoice class
        /// </summary>
        [Test]
        public void GivenMultipleRide_ReturnNumberOfRideAggregrateFareAndAverageFare()
        {
            /// Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            /// Act
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            var resultHashCode = invoiceSummary.GetHashCode();
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(30.0, 2, 15.0);
            var resulExpectedHashCode = expectedInvoiceSummary.GetHashCode();
            /// Assert
        }
        /// <summary>
        /// TC 4- Given the user Id for a particular customer using the Cab Service must return the invoice summary along woth ride list
        /// </summary>
        [Test]
        public void GivenUserId_ShouldReturnInvoiceSummary()
        {
            /// Arrange - initialising the instance of the invoice generator class
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            /// Creating the instance of the ride repository
            RideRepository repository = new RideRepository();
            /// Initialising the user ID
            string userID = "abc@d.com";
            /// Initialising the ride array with details of the ride or ride statistics
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            /// Adding the ride data for the user to the ride repository
            repository.AddRide(userID, rides);
            /// Getting the ride data from the ride repository class using the user ID
            Ride[] rideData = repository.GetRides(userID);
            /// Getting the invoice summary when passing the ride Data
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rideData);
            /// Expected value of the Invoice Summary
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(30.0, 2, 15.0);
            /// Asserting the comparison between the expected and actual invoice summary
            Assert.AreEqual(expectedInvoiceSummary, invoiceSummary);
        }
    }
}