using System;
namespace TimerEvents
{
    /// <summary>
    /// Holds the parameters, needed for the called by the TimerEvent methods
    /// </summary>
    public class Print5EventArgs : EventArgs
    {
        private int[] myArr;

        internal int[] MyArr
        {
            get { return this.myArr; }
            set
            {
                if (value == null) throw new NullReferenceException("The array of integers is probably not initialized!");
                this.myArr = value;
            }
        }

        internal Print5EventArgs(int[] myArr)
        {
            this.MyArr = myArr;
        }
    }

}
