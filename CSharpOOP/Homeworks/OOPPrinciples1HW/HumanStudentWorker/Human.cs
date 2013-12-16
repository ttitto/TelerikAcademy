using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentWorker
{
    public abstract class Human
    {
        private string fName;
        private string lName;

        public string FName
        {
            get { return this.fName; }
            set
            {
                if (value == null) throw new ArgumentNullException("First name can not be null!");
                this.fName = value;
            }
        }
        public string LName
        {
            get { return this.lName; }
            set
            {
                if (value == null) throw new ArgumentNullException("Last name can not be null!");
                this.lName = value;
            }
        }

        public Human(string fName, string lName)
        {
            this.FName = fName;
            this.LName = lName;
        }
    }
}
