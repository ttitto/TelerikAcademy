using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
#region Exercise 
/*1.  Define a class that holds information about a 
 * mobile phone device: * model, manufacturer, price, owner, 
 * battery characteristics (model, hours idle and hours talk) and 
 * display characteristics (size and number of colors). 
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
*/

/*2. Define several constructors for the defined classes that take different sets of arguments
 * (the full information for the class or part of it). Assume that model and manufacturer are
 * mandatory (the others are optional). All unknown data fill with null.
*/

/*5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
 * Ensure all fields hold correct data at any given time.*/

/*7. Write a class GSMTest to test the GSM class:
Create an array of few instances of the GSM class.
Display the information about the GSMs in the array.
Display the information about the static property IPhone4S.*/


#endregion

namespace Ex1MobilePhoneClass
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GSM[] myGSMs = new GSM[4] { new GSM("Nokia", "Asha 401", 340.5m), new GSM("Nokia", "7200", "Нели", 205m),
                new GSM("Nokia","101","Елиа",54.49m), new GSM("Nokia","6210","Тодор",44.25m) };
            foreach (var item in myGSMs)
            {
                Console.WriteLine(item.ToString());
            }
            
            Console.WriteLine(GSM.IPhone4S.ToString());
            GSMCallHistoryTest.GSMCallHistoryTestMethod();
            //GSM myMobile = new GSM("Nokia", "Asha 501", "Todor",542.41m);
            //Console.WriteLine(myMobile.Manufacturer);
            //Console.WriteLine(myMobile.Model);
            //Battery myBattery = new Battery("Model");
            //Console.WriteLine(myBattery.Model + " " + myBattery.BatteryType);
            //GSM.PrintGSMInfo(myMobile);
        }
    }
}
