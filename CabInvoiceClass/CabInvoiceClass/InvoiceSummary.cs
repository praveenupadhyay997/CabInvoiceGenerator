using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceClass
{
    public class InvoiceSummary
    {
        /// <summary>
        /// Attributes for the invoice summary length = length of the journey
        /// totalfare = computed totalfare of the 
        /// </summary>
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        public int length;
        /// <summary>
        /// Parameterised constructor to initialise the data attributes with the user defined values
        /// </summary>
        /// <param name="totalFare"></param>
        /// <param name="length"></param>
        public InvoiceSummary(double totalFare, int length)
        {
            this.totalFare = totalFare;
            this.length = length;
        }
        /// <summary>
        /// Over riding the Equals method so as to match the value of the object references
        /// Default Equals method comapre the reference of the objects and not the values
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;
            InvoiceSummary invoice = (InvoiceSummary)obj;
            return ((this.numberOfRides == invoice.numberOfRides) && (this.totalFare == invoice.totalFare) && (this.averageFare == invoice.averageFare));
        }
        /// <summary>
        /// Overriding equals method require overriding the GetHashCode method too else we get a compiler warning
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode() ^ this.length.GetHashCode();
        }
    }
}




