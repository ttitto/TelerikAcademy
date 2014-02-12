using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Students
{
    class Student
    {

        public Student(string fName, string lName, string fN, int groupNumber)
        {
            this.FName = fName;
            this.LName = lName;
            this.FN = fN;
            this.GroupNumber = groupNumber;
            this.Marks = new List<int>().AsEnumerable();
        }

        private string fName;
        private string lName;
        private string fN;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;

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
                if (null == value) throw new ArgumentNullException("Last name can not be null!");
                this.lName = value;
            }
        }

        public string FN
        {
            get { return this.fN; }
            set
            {
                if (null == value) throw new ArgumentNullException("FN can not be null!");
                this.fN = value;
            }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                string rgxStr = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!Regex.IsMatch(value, rgxStr)) throw new ArgumentException("Invalid email address!");
                this.email = value;
            }
        }

        public IEnumerable<int> Marks
        {
            get { return this.marks; }
            set
            {
                if (null == value) throw new ArgumentNullException("Marks can not be null!");
                this.marks = value.ToList();
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public override string ToString()
        {
            string notes=string.Empty;
            foreach (var item in this.Marks)
            {
                notes += " " + item;
            }
            return String.Format("{0} {1}, FN:{2}, Group:{3}, notes:{{{4}}}", this.FName, this.LName, this.FN, this.GroupNumber,notes); ;
        }

    }
}
