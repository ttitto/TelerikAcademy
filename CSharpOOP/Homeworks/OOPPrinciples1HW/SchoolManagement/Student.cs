using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SchoolManagement
{

    internal class Student : IPerson, ICommentable
    {
        #region Fields
        private string name;
        private uint number;
        private string comment;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null) throw new ArgumentException("Student's name can not be null!");
                this.name = value;
            }
        }
        public uint Number
        {
            get { return this.number; }
            set
            {
                if (value == 0) throw new ArgumentException("Student's number can not be null!");
                else this.number = value;
            }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        } 
        #endregion

        #region Constructors
        public Student(string name, uint number)
        {
            this.Number = number;
            this.Name = name;
        }
        #endregion

        #region Methods
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }
        public void ShowComment()
        {
            Console.WriteLine(this.Comment);
        } 
        #endregion
    }
}
