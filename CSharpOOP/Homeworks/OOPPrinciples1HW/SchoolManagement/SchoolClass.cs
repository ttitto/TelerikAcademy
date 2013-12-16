using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SchoolManagement
{
    internal class SchoolClass : ICommentable
    {
        private string classID;
        private string comment;
        private Dictionary<uint,Student> students=new Dictionary<uint,Student>();
        private List<Teacher> teachers;

        public string ClassID
        {
            get { return this.classID; }
            set
            {
                if (value == String.Empty || value == null)
                    throw new ArgumentException("School Class identification can not be empty or null");
                this.classID = value;
            }
        }
        public IEnumerable<Student> Students
        {
            get { return this.students.Values.AsEnumerable<Student>(); } 
        }
        public IEnumerable<Teacher> Teachers
        {
            get { return this.teachers; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Teachers list can not be null!");
                this.teachers = value.ToList<Teacher>();
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public SchoolClass(string classID, Dictionary<uint,Student> students, List<Teacher> teachers)
        {
            this.ClassID = classID;
            foreach (var item in students)
            {
                AddStudent(item.Value);
            }
            this.Teachers = teachers;
        }

        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        public void ShowComment()
        {
            Console.WriteLine(this.Comment);
        }
        /// <summary>
        /// Checks if a student with the same number already exists in the current schoolClass.
        /// If it does throws an exception. If it doesn't adds the argument
        /// </summary>
        /// <param name="student">Holds an object of the class Student</param>
        public void AddStudent(Student student)
        {
            if (this.students.ContainsKey(student.Number)  )
                throw new ArgumentException("There are students in the list with the same class number!");
            else this.students.Add(student.Number,student);
        }
      
    }
}
