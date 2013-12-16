using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AllDivisibleBy7And3;
namespace TimerDelegates
{
    public delegate void MethodCaller();
             
 public  class Timer
    {
     
        private int interval;
        public MethodCaller myDelegate;

        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value for the repetition interval!");
                this.interval = value;
            }
        }
        public Timer(int interval, MethodCaller myDelegate)
        {
            this.Interval = interval;
            this.myDelegate = myDelegate;
            Thread newThread = new Thread(() =>//for parallel execution of methods 
            {
                while (true)
                {
                    this.myDelegate();
                    Thread.Sleep(this.Interval);
                }
            });    
            newThread.Start();
        }
    }

}
