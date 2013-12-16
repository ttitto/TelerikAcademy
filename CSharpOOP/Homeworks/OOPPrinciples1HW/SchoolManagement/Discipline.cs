using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
    public class Discipline : ICommentable
    {
        private string name;
        private uint numOfLectures;
        private uint numOfExercises;
        private string comment;

        public string Name
        {
            get { return this.name; }
            set {
                if (value == null) throw new ArgumentNullException("Discipline name can't be null!");
                this.name=value;}
        }

        public uint NumOfLectures
        {
            get { return this.numOfLectures;}
            set { this.numOfLectures=value;}
        }

        public uint NumOfExercises
        {
            get { return this.numOfExercises;}
            set { this.numOfExercises=value;}
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        public Discipline(string name, uint numOfLectures, uint numOfExercises)
        {
            this.Name = name;
            this.NumOfLectures = numOfLectures;
            this.NumOfExercises = numOfExercises;
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
