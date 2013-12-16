using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty.
namespace StudentsStory
{
    class Student :ICloneable, IComparable<Student>
    {
        #region Fields
        string firstName;
        string middleName;
        string lastName;
        string address;
        string phone;
        string email;
        string course;
        string socialSN;
        Specialties specialty;
        Universities university;
        Faculties faculty;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null) throw new ArgumentNullException("First name can not be null!");
                this.firstName = value;
                ;
            }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (value == null) throw new ArgumentNullException("Middle name can not be null!");
                this.middleName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null) throw new ArgumentNullException("Last name can not be null!");
                this.lastName = value;
            }
        }
        public string Address
        {
            get { return this.address; }
            set
            {
                if (value == null) throw new ArgumentNullException("Address can not be null!");
                this.address = value;
            }
        }
        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (value.All(d => Char.IsDigit(d))) throw new ArgumentException("Phone number must contain only digits!");
                this.phone = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (!IsValidEmail(value)) throw new ArgumentException("Invalid email!");
                this.email = value;
            }
        }
        public string Course
        {
            get { return this.course; }
            set
            {
                if (value == null) throw new ArgumentNullException("Course can not be null!");
                this.course = value;
            }
        }
        public string SocialSN
        {
            get { return this.socialSN; }
            set
            {
                if (value == null) throw new ArgumentNullException("SSN can not be null!");
                this.socialSN = value;
            }
        }
        public Specialties Specialty
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }
        public Universities University
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public Faculties Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }
        #endregion

        #region Constructors
        public Student(string firstName, string middleName, string lastName, string socialSN, Universities university, Specialties specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSN = socialSN;
            this.University = university;
            this.Specialty = specialty;
        }
        #endregion

        #region Methods
        private bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn)) return false;

            return Regex.IsMatch(strIn,
                  @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$",
                  RegexOptions.IgnoreCase);
        }
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null) return false;
            if (this.SocialSN == student.SocialSN) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return SocialSN.GetHashCode() ^ this.LastName.GetHashCode();
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.SocialSN + " " + this.Specialty;
        }
        #endregion

        #region Operators
        public static bool operator ==(Student st1, Student st2)
        {
            return Student.Equals(st1, st2);
        }
        public static bool operator !=(Student st1, Student st2)
        {
            return !Student.Equals(st1, st2);
        }
        #endregion

        /// <summary>
        /// Creates a deep clone of a Student instance. A Student has only value type members,
        /// therefore calling this.MemberwiseClone() does the deep cloning alone.
        /// </summary>
        /// <returns>Object type</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Compares two students by names alphabetically and by increasing social security number
        /// </summary>
        /// <param name="other"></param>
        /// <returns>zero - if the students have the same names and social security numbers, 
        /// "-1" - if the first student's names are alphabetically earlier or his SSN is smaller
        /// "1" - if the first student's names are alphabetically later or his SSN is bigger</returns>
        public int CompareTo(Student other)
        {
            if (this.FirstName + this.MiddleName + this.LastName == other.FirstName + other.MiddleName + other.LastName)
            {
                if (this.SocialSN == other.SocialSN) return 0;
                else if (long.Parse( this.SocialSN).CompareTo(long.Parse( other.SocialSN)) == 1) return 1;
                else return -1;
            }
            else if ((this.FirstName + this.MiddleName + this.LastName).CompareTo(other.FirstName + other.MiddleName + other.LastName) == 1) return 1;
            else return -1;
        }
    }
}
