using System;

namespace TimerEvents
{
    class TimerEventsClass
    {
        static void Main(string[] args)
        {
            int[] myArr = new int[10] { 3, 8, 21, 54, 49, 69, -42, 64, 42, 46 };
            Timer t = new Timer(1000);//Instance of the publishing class (that raises the event)
            Subscriber sub1 = new Subscriber(t); //instance of the subscriber class
            // Call the method that raises the event.
            t.RaiseTimerEvent(new Print5EventArgs(myArr));
            Console.WriteLine("Press ctrl+C to close this window.");
            // Keep the console window open
            Console.ReadLine();

        }
    }
}
