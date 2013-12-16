namespace InvalidRange
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidRangeException<T> : System.Exception where T : IConvertible
    {
        private string message;
        private T minValue;
        private T maxValue;

        public string Message
        {
            get { return this.message; }
            set
            {
                if (value == null) throw new ArgumentNullException("Message can't be null!");
                this.message = value;
                ;
            }
        }
        public T MinValue
        {
            get { return this.minValue; }
        }
        public T MaxValue
        {
            get { return this.maxValue; }
        }

        public InvalidRangeException()
        {
            this.minValue = GetValidMinValue<T>();
            this.maxValue = GetValidMaxValue<T>();
            this.Message = String.Format(" Valid values must be in the range: {0} and {1}!", GetValidMinValue<T>(), GetValidMaxValue<T>());
        }
        public InvalidRangeException(string message)
            : base(message)
        {
            this.minValue = GetValidMinValue<T>();
            this.maxValue = GetValidMaxValue<T>();
            this.Message = base.Message + String.Format(" Valid values must be in the range: {0} and {1}!", GetValidMinValue<T>(), GetValidMaxValue<T>());
        }
        public InvalidRangeException(string message, Exception innerEx)
            : base(message, innerEx)
        {
            this.Message = base.Message + String.Format(" Valid values must be in the range: {0} and {1}!", GetValidMinValue<T>(), GetValidMaxValue<T>());
        }
        protected InvalidRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Message = base.Message + String.Format(" Valid values must be in the range: {0} and {1}!", GetValidMinValue<T>(), GetValidMaxValue<T>());
        }
        ////Returns a runtime error Type must implement IConvertible
        //private static T[] GetValidRange<T>()
        //{
        //    if (typeof(T) == typeof(Int32)) return (T[])Convert.ChangeType(new int[] { 1, 100 }, typeof(Int32));
        //    else if (typeof(T) == typeof(Int32)) return (T[])Convert.ChangeType(new DateTime[] { new DateTime(1980, 1, 1), new DateTime(2013, 12, 31) }, typeof(DateTime));
        //    else throw new ArgumentException("A valid range for this type T is not defined!");
        //}

        //Determinates the type and assigns a minimum value that is valid
        private static T GetValidMinValue<T>()
        {
            if (typeof(T) == typeof(int)) return (T)Convert.ChangeType(1, typeof(Int32));
            else if (typeof(T) == typeof(DateTime)) return (T)Convert.ChangeType(new DateTime(1980, 1, 1), typeof(DateTime));
            else throw new ArgumentException("A valid range for the minimum value is not defined!");
        }
        private static T GetValidMaxValue<T>()
        {
            if (typeof(T) == typeof(int)) return (T)Convert.ChangeType(100, typeof(Int32));
            else if (typeof(T) == typeof(DateTime)) return (T)Convert.ChangeType(new DateTime(2013, 12, 31), typeof(DateTime));
            else throw new ArgumentException("A valid range for the maximum value is not defined!");
        }

        //public override void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    base.GetObjectData(info, context);

        //    if (info != null)
        //    {
        //        info.AddValue("MinValue", this.minValue);
        //        info.AddValue("MaxValue",this.maxValue);
        //    }
        //}

    }
}
