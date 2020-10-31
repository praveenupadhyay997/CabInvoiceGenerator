// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace CabInvoiceClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Welcome to the Cab Invoice Generator");
            Console.WriteLine("====================================");
            /// Creating the instance of the invoice generator class
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            if(invoiceGenerator.rideType.Equals(RideType.PREMIUM))
                Console.WriteLine("Welcome to Premium rides....");
            /// Creating the instance of the ride repository class
            RideRepository repository = new RideRepository();
            /// Passing the user ID as a variable
            string userID = "abc@d.com";
            /// Storing the ride history in a Rise Type array
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            /// Adding the data to the ride repository class instance
            repository.AddRide(userID, rides);
            /// UC- 4 Getting the ride history when passing the User ID
            Ride[] mappedData = repository.GetRides(userID);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(mappedData);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(30.0, 2, 15.0);
            /// Comparing the invoice summary
            Console.WriteLine(Convert.ToString("Total Fare = "+ invoiceSummary.totalFare)+ 
                "\nTotal Number of Rides = " + invoiceSummary.length+ 
                "\nAverage Fare of the ride = "+Convert.ToString(invoiceSummary.averageFare));
        }
    }
}
