// -----------------------------------------------------------------------
// <copyright file="GSM.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex1MobilePhoneClass
{
    /*3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.*/

    /*4. Add a method in the GSM class for displaying all information about it. Try to override ToString().*/

    /*6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.*/

    /*9. Add a property CallHistory in the GSM class to hold a list of the performed calls.
     * Try to use the system class List<Call>.*/

    /*10. Add methods in the GSM class for adding and deleting calls from the calls history.
     * Add a method to clear the call history.*/

    /*11. Add a method that calculates the total price of the calls in the call history.
     * Assume the price per minute is fixed and is provided as a parameter.*/

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///Defines an object GSM
    /// </summary>
    public class GSM
    {
        #region Fields
        string model;
        string manufacturer;
        decimal price;
        string owner;
        static GSM iPhone4S;
        List<Call> callHistory = new List<Call>();
        #endregion

        #region Constructors
        /// <summary>
        /// Builds a GSM object.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="owner"></param>
        /// <param name="price"></param>
        public GSM(string manufacturer, string model, string owner, decimal price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Owner = owner;
            this.Price = price;
        }
        /// <summary>
        ///  Builds a GSM object.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        public GSM(string manufacturer, string model)
            : this(manufacturer, model, null, 0m)
        {
        }
        /// <summary>
        ///  Builds a GSM object.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="owner"></param>
        public GSM(string manufacturer, string model, string owner)
            : this(manufacturer, model, owner, 0m)
        {
        }
        /// <summary>
        ///  Builds a GSM object.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="price"></param>
        public GSM(string manufacturer, string model, decimal price)
            : this(manufacturer, model, null, price)
        {
        }
        /// <summary>
        ///  Builds a GSM object.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="battery"></param>
        /// <param name="display"></param>
        public GSM(string manufacturer, string model, Battery battery, Display display)
            : this(manufacturer, model, null, 0m)
        {
            this.battery = null;
            this.display = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Defines the model of a GSM object
        /// Can not be empty, null or whitespace!
        /// </summary>
        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value) | String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid model value!");
                this.model = value;
            }
        }
        /// <summary>
        /// Defines the manufacturer of a GSM object.
        /// Can not be empty, null or whitespace!
        /// </summary>
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value) | String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid manufacturer value");
                this.manufacturer = value;
            }
        }
        /// <summary>
        /// Defines the price of a GSM object
        /// Can not be negative!
        /// </summary>
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0) throw new ArgumentException("Negative price is not allowed!");
                this.price = value;
            }
        }
        /// <summary>
        /// Defines the owner of a GSM object.
        /// Can be any value or Null.
        /// </summary>
        public string Owner
        {
            get { return this.owner; }
            set
            {
                this.owner = value;
            }
        }
        /// <summary>
        /// Defines IPhone4S object of the class GSM.
        /// </summary>
        public static GSM IPhone4S
        {
            get { return new GSM("Apple", "IPhone 4S", "some rich woman", 998.00m); }
            //set { if (value != null) iPhone4S = new GSM("Apple", "IPhone 4S", "some rich woman", 998.00m); }
        }
        /// <summary>
        /// Defines a Callhistory for a GSM object
        /// Must be a List of Call objects.
        /// </summary>
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { value = this.callHistory; }
        }
        #endregion

        //Instances of Battery and Display
        Display display = new Display(15.6f, 65000);
        Battery battery = new Battery("China");

        #region Methods
        /// <summary>
        /// Prints the information for a GSM object on the console.
        /// </summary>
        /// <param name="myGSM"></param>
        public static void PrintGSMInfo(GSM myGSM)
        {
            Console.WriteLine(myGSM.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder GSMInfo = new StringBuilder();
            GSMInfo.AppendLine(String.Format("GSM Manufacturer: {0}", this.Manufacturer));
            GSMInfo.AppendLine("GSM Model: " + this.Model);
            GSMInfo.AppendLine("GSM Battery: "+this.battery.ToString());
            GSMInfo.AppendLine("GSM Display: "+this.display.ToString());
            GSMInfo.AppendLine("GSM Price: " + this.Price);
            GSMInfo.AppendLine("GSM Owner: " + this.Owner);
            return GSMInfo.ToString();
        }
        /// <summary>
        /// Prints the information for the current Instance of the GSM class.
        /// As an addition it prints also the call history if the parameter showCallHistory is true
        /// </summary>
        /// <param name="showCallHistory">If false - returns current GSM info without call history, if true - returns also the call history for the currrent GSM</param>
        /// <returns></returns>
        public string ToString(bool showCallHistory)
        {
            if (!showCallHistory) return ToString();
            else
	{
        StringBuilder callHistoryInfo = new StringBuilder();
        callHistoryInfo.AppendLine(ToString());
        if (this.callHistory != null)
        {
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                callHistoryInfo.AppendLine((i + 1) + " " + callHistory[i].ToString());
            }
        }
        return callHistoryInfo.ToString();
	}
        }
        /// <summary>
        /// Adds a call to the call history.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="callDuration"></param>
        public void AddCall(DateTime date, DateTime time, string phoneNumber, TimeSpan callDuration)
        {
            this.callHistory.Add(new Call(date, time, phoneNumber, callDuration));
        }
        /// <summary>
        /// Removes call(s) from the call history.
        /// If a single call must be removed, as parameter is given the number of the call as start and end call, ex. 11,11.
        /// If a range of calls will be deleted, the first call and the last call are given as parameters, ex. 11,16
        /// </summary>
        /// <param name="start">the fisrt  call in the range that will be removed</param>
        /// <param name="end">the last call in the range that will be removed</param>
        public void RemoveCalls(int start, int end)
        {           
            this.callHistory.RemoveRange(start, end - start+1);
        }
        /// <summary>
        /// Removes all the calls from the call history. Asks for confirmation before deletion.
        /// </summary>
        public void ClearCallHistory()
        {
            Console.Write("This will delete all calls in the history! Proceed? y/n :");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                this.callHistory.Clear();
            }
            else return;
        }
        /// <summary>
        /// Calculates the calls costs if a price per minute is given as a parameter.
        /// The calculation is made exactly for the total used seconds and not for a started minute.
        /// </summary>
        /// <param name="minutePrice"></param>
        /// <returns>The total costs for the calls in the history.</returns>
        public decimal CalculateCallsCosts(decimal minutePrice)
        {
            return minutePrice * (decimal)this.callHistory.Sum(c => c.CallDuration.TotalSeconds) / 60;
        }
        #endregion
    }
}
