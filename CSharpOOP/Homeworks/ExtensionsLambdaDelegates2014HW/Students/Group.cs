using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.departmentName = departmentName;
            this.groupNumber = groupNumber;
        }

        int groupNumber;
        string departmentName;

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }


        public string DepartmentName
        {
            get { return this.departmentName; }
            set { this.departmentName = value; }
        }


    }
}
