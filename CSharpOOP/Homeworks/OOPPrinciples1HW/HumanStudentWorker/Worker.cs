using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentWorker
{
    public class Worker : Human
    {
        decimal weekSalary;
        float workHoursPerDay;


        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                this.weekSalary = value;
            }
        }
        public float WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24) throw new ArgumentException("The work hours per can't be negative or more than 24");
                this.workHoursPerDay = value;
                ;
            }
        }

        public Worker(string fName, string lName)
            :base(fName,lName)
        {
        }
        public Worker(string fName, string lName, float workHoursPerDay, decimal weekSalary)
            : base(fName, lName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }
        /// <summary>
        /// Returns the earning per hour of a worker by dividing the weekly salary of the sum of working hours
        /// </summary>
        /// <param name="workDays">holds the working days in a week</param>
        /// <returns></returns>
        public decimal MoneyPerHour(uint workDays)
        {
            decimal result=0;
            if (workDays < 0 || workDays > 7) throw new ArgumentException("Workdays can't be negative or more than 7!");
            result =this.WeekSalary/ (decimal)(workDays * this.WorkHoursPerDay);
            return result;
        }
    }
}
