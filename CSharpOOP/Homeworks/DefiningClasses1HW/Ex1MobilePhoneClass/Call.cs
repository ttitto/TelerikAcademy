using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex1MobilePhoneClass
{
    /*8. Create a class Call to hold a call performed through a GSM. 
     * It should contain date, time, dialed phone number and duration (in seconds).*/
    /// <summary>
    /// Defines Call objects
    /// </summary>
   public class Call
    {
        #region Fields
        DateTime date;
        DateTime time;
        string phoneNumber;
        TimeSpan callDuration;
        #endregion

        #region Properties
       /// <summary>
       /// The date that a call was made.
       /// The date must be after 01.01.0001 and below 31.12.9999
        ///  Checking if the value is valid is not necessary. It is automatically done and an exception is thrown.
       /// </summary>
        public DateTime CallDate
        {
            get { return this.date; }
            set
            {
              // if (value < new DateTime(0001, 01, 01) || value>new DateTime(9999,12,31)) throw new ArgumentException();
                this.date=value;
            }
        }
       /// <summary>
       /// The time a call was made.
        ///  Checking if the value is valid is not necessary. It is automatically done and an exception is thrown.
       /// </summary>
        public DateTime CallTime
        {
            get { return this.time; }
            set
            {
               // if (value < new DateTime(0001, 01, 01) || value > new DateTime(9999, 12, 31)) throw new ArgumentException();
                this.time=value;
            }
        }
       /// <summary>
       /// The number that was called.
       /// Can contain only digits and the characters -+)(.
       /// </summary>
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                Regex phoneNumValidation = new Regex(@"[^0-9\-\+\)\(]");
                if (phoneNumValidation.IsMatch(value) || String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The Phone Number contains characters that are not allowed");
                this.phoneNumber=value;
            }
        }
       /// <summary>
       /// The duration of a call
        /// Can't be zero or less.
       /// </summary>
        public TimeSpan CallDuration 
        {
            get { return this.callDuration; }
            set
            {
                if (value.Seconds <= 0) throw new ArgumentException("Invalid call duration!");
                this.callDuration=value;
            }
        }

        #endregion

        #region Constructors
       /// <summary>
       /// Builds a Call object.
       /// </summary>
       /// <param name="date"></param>
       /// <param name="time"></param>
       /// <param name="phoneNumber"></param>
       /// <param name="callDuration"></param>
        public Call(DateTime date, DateTime time, string phoneNumber, TimeSpan callDuration)
        {
            this.CallDuration = callDuration;
            this.CallDate=date;
            this.CallTime=time;
            this.PhoneNumber = phoneNumber;
        }
        #endregion

        #region Methods
       /// <summary>
       /// Overrides the ToString() method to return a string with the information for the Call object.
       /// </summary>
       /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder callInfo = new StringBuilder();
            callInfo.Append(this.CallDate.ToShortDateString()+", "+this.CallTime.ToShortTimeString()+", "+this.PhoneNumber+", "+this.callDuration.TotalSeconds);
            return callInfo.ToString();
        }
        #endregion
    }
}
