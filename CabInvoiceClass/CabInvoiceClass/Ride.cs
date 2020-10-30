// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ride.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceClass
{
    public class Ride
    {
        /// <summary>
        /// Memeber attributes to get the drive summary
        /// </summary>
        public double distance;
        public int time;
        /// <summary>
        /// Parameterised Constructor to initialise theinstance of the ride class summary
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
