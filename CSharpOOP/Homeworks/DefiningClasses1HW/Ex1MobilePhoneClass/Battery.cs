
namespace Ex1MobilePhoneClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the possible types of bateries
    /// </summary>
    public enum BatteryTypes : byte { LiOn = 1, NiCd, NiMH };

    /// <summary>
    ///Defines objects of type Battery
    /// </summary>
    public class Battery
    {
        //Fields
        string model;
        TimeSpan hoursIdle;
        TimeSpan hoursCall;
        BatteryTypes? batteryType = new BatteryTypes();

        #region Constructors
        /// <summary>
        /// Builds Battery objet
        /// </summary>
        /// <param name="model"></param>
        public Battery(string model)
            : this(model, null)
        {
        }
        /// <summary>
        /// Builds Battery object
        /// </summary>
        /// <param name="model">Battery model</param>
        /// <param name="baterytype">Batery types from the BatteryTypes Enumeration or null</param>
        public Battery(string model, BatteryTypes? baterytype)
        {
            this.Model = model;
            this.BatteryType = baterytype;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Model property of a Battery. Can not be null, empty or whitespace!
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value) | String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid model!");
                this.model = value;
            }
        }
        /// <summary>
        /// Defines how many hours the battery can hold in idle mode.
        /// Can not be zero or less!
        /// </summary>
        public TimeSpan HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value.TotalSeconds <= 0) throw new ArgumentException("Invalid Idle Hours value!");
                this.hoursIdle = value;
            }
        }
        /// <summary>
        /// Defines how many hours the batery can hold in calls mode.
        /// Can't be zero or less!
        /// </summary>
        public TimeSpan HoursCall
        {
            get { return this.hoursIdle; }
            set
            {
                if (value.TotalSeconds<= 0) throw new ArgumentException("Invalid Call Hours value!");
                this.hoursCall = value;
            }
        }
       
        public BatteryTypes? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Overrides the method ToString() so that it shows the properties for a Battery Object
        /// </summary>
        /// <returns> as string with the battery object information</returns>
        public override string ToString()
        {
            return string.Format("Model: {0}, BatteryType: {3},Hours Idle: {1}, Hours Call: {2}",this.Model,this.HoursIdle,this.HoursCall, this.BatteryType);
        }
        #endregion

    }
}
