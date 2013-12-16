using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex1MobilePhoneClass
{
    /*12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
Create an instance of the GSM class.
Add few calls.
Display the information about the calls.
Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
Remove the longest call from the history and calculate the total price again.
Finally clear the call history and print it.*/
   public class GSMCallHistoryTest
    {
        static Random rnd = new Random();
       /// <summary>
       /// 
       /// </summary>
        public static void GSMCallHistoryTestMethod()
        {
            //create an instance of the GSM class
            GSM myGSM = new GSM("Samsung", "Galaxy Note3", "Пламен", 101.99m);
            //add few calls. Random number of call with random combinations of call properties
            List<DateTime> myDates = new List<DateTime>() { new DateTime(2013, 09, 13), new DateTime(2013, 09, 14),
                new DateTime(2013, 09, 15), new DateTime(2013, 09, 16), new DateTime(2013, 09, 17) };
            List<DateTime> myTimes = new List<DateTime>() { new DateTime(2013, 09, 13, 15, 34, 25), new DateTime(2013, 09, 13, 10, 26, 14),
            new DateTime(2013, 09, 13,07,55,38),new DateTime(2013, 09, 13,20,01,02),new DateTime(2013, 09, 13,16,02,34)};
            List<string> myDialNumbers = new List<string>() {"0888255654","0889654987","0885123456","+359(0886)852456","0898256741" };
            List<TimeSpan> myDurations = new List<TimeSpan>(){new TimeSpan(0,20,46),new TimeSpan(0,34,26),new TimeSpan(0,07,57),
                new TimeSpan(00,05,42),new TimeSpan(0,17,29)};
           int numOfCalls= rnd.Next(1, 100);
           for (int i = 0; i < numOfCalls; i++)
           {
               myGSM.AddCall(myDates[rnd.Next(0,4)],myTimes[rnd.Next(0,4)],myDialNumbers[rnd.Next(0,4)],myDurations[rnd.Next(0,4)]);
           }
            //Display the information about the calls. Implemented with an overload of the overriden ToString() Method
           Console.WriteLine(myGSM.ToString(true));
           Console.WriteLine("The total calls' price is {0:N} lv.",myGSM.CalculateCallsCosts(0.37m));
            //Remove the longest call and recalculate the price
            //if there are more than one call with the same maximal length, removes them all
           double maxCallDuration = myGSM.CallHistory.Max(m => m.CallDuration.TotalSeconds);
           for (int i = 0; i < myGSM.CallHistory.Count(); i++)
           {
               if (myGSM.CallHistory[i].CallDuration.TotalSeconds == maxCallDuration)
               {
                   myGSM.RemoveCalls(i, i);
                   i--;
               }
           }
           Console.WriteLine(myGSM.ToString(true));
           Console.WriteLine("The total calls' price is {0:N} lv.", myGSM.CalculateCallsCosts(0.37m));

            //Clear the whole history and print it again
           myGSM.ClearCallHistory();
           Console.WriteLine(myGSM.ToString(true));
           Console.WriteLine("The total calls' price is {0:N} lv.", myGSM.CalculateCallsCosts(0.37m));
        }
    }
}
