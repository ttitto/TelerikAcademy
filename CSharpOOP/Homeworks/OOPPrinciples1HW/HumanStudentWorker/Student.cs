using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentWorker
{
    internal class Student : Human
    {
        private string grade;

        public string Grade
        {
            get { return this.grade; }
            set
            {
                if (value == null) throw new ArgumentNullException("Student's grade can not be null!");
                this.grade = value;
            }
        }

        public Student(string fName, string lName)
            : base(fName,lName)
        {
        }
        public Student(string fName, string lName,string grade)
            : base(fName,lName)
        {
            this.Grade = grade;
        }
    }
}
