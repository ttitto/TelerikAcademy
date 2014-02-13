// -----------------------------------------------------------------------
// <copyright file="Subscriber.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TimerEvents
{
    using System;

    /// <summary>
    ///Subscribes all the delegate instances to their subscribed methods 
    /// </summary>
    class Subscriber
    {
        internal Subscriber(Timer t)
        {
            // In this case the instance TimerEvent of the EventHandler
            t.TimerEvent += Print5;
        }

        //Implementation of the subscribed methods. They could be also in another class, or even namespace
        void Print5(object sender, Print5EventArgs e)
        {
            int printLimit = 5;
            if (e.MyArr.Length < 6) printLimit = e.MyArr.Length;
            for (int i = 0; i < printLimit; i++)
            {
                Console.Write(e.MyArr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

}
