using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
    internal class Teacher : IPerson, ICommentable
    {
        private string name;
        private string comment;
        private List<Discipline> disciplines;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        /// <summary>
        /// IEnumerable doesn't allow Add and InsertAt methods to be used to modify 
        /// the List<Discipline>()and avoid the validation in the property
        /// This is valid everywhere in this code: Lists, arrays, dictionaries and other private fields are exposed as IEnumerable<>
        /// </summary>
        public IEnumerable<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set
            {
                if (value == null) throw new ArgumentException("Disciplines list can not be null!");
                this.disciplines = value.ToList<Discipline>();
            }
        }

        public Teacher(string name, List<Discipline> disciplines)
        {
            this.Name = name;
            this.Disciplines = disciplines;
        }

        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        public void ShowComment()
        {
            Console.WriteLine(this.Comment);
        }
    }
}
