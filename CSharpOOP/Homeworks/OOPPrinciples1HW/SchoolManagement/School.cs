using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
    class School
    {
        private List<SchoolClass> schoolClasses;
        public IEnumerable<SchoolClass> SchoolClasses
        {
            get { return this.schoolClasses; }
            set
            {
                if (value == null) throw new ArgumentException();
                //checks if the count of the new list is the same as the list of only distinct values
                if (value.Count() != value.Select(sc => sc.ClassID).Distinct().Count())
                    throw new ArgumentException("Duplicated class IDs!");
                this.schoolClasses = value.ToList();
            }
        }
        public School(List<SchoolClass> schoolClasses)
        {
            this.SchoolClasses = schoolClasses;
        }
        public void AddClass(SchoolClass schoolClass)
        {
            if (this.SchoolClasses.Any(sc => sc.ClassID == schoolClass.ClassID))
                throw new ArgumentException("Duplicated class ID!");
            else this.schoolClasses.Add(schoolClass);
        }
    }
}
