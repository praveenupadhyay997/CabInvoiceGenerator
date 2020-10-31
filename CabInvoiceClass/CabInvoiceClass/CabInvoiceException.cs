// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CabInvoiceException.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceClass
{
    [Serializable]
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Custom Exception Class to denote the exception  internally generated
        /// </summary>
        public ExceptionType exceptionType;
        /// <summary>
        /// Exception enumerator to denote the internal message
        /// </summary>
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_RIDETYPE,
            INVALID_USER_ID,
            INVALID_RIDE_TYPE
        }
        // Parameterised constructor to override the base class message
        public CabInvoiceException(ExceptionType innerException, string message) : base(message)
        {
            this.exceptionType = innerException;
        }
    }
}
