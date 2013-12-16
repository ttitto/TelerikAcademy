using System;
using System.Threading;
namespace TimerEvents
{
   /// <summary>
   /// 
   /// </summary>
   public class Timer
    {
        // Declare the event using EventHandler<T> delegate
        public event EventHandler<Print5EventArgs> TimerEvent;
        private uint interval;
        public uint Interval
        {
            get { return this.interval; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value for timer interval!");
                this.interval = value;
            }
        }
        public Timer(uint interval)
        {
            this.Interval = interval;
        }

        public void RaiseTimerEvent(Print5EventArgs e)
        {
            //The TimerEvent will be null if it has no subscribers
            //that is why I do this check
            if (TimerEvent != null)
            {
                //Raises the TimerEvent in a new Thread in equal intervals and sends to the
                //subscribers to TimerEvent the properties of the Print5EventArgs
                Thread newThread = new Thread(() =>
                {
                    while (true)
                    {
                        TimerEvent(this, e);
                        Thread.Sleep((int)this.Interval);
                    }
                });
                newThread.Start();
            }
        }
    }
}