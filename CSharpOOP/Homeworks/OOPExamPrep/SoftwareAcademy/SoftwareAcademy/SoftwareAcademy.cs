using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        private string name;
        private ITeacher teacher;
        private List<string> topics;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ITeacher Teacher
        {
            get { return this.teacher; }
            set { this.teacher = value; }
        }
        public IEnumerable<string> Topics
        {
            get { return this.topics.AsEnumerable(); }
            set { this.topics = value.ToList(); }
        }
        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name={0}; ", this.Name);

            if (this.Teacher != null)
            {
                sb.Append(string.Format("Teacher={0}; ", this.Teacher.Name));
            }

            if (this.Topics.Count() != 0)
            {
                sb.Append("Topics=[");
                foreach (var item in this.Topics)
                {
                    sb.Append(item);
                    sb.Append(", ");
                }
                if ((sb.ToString().Substring(sb.Length - 2, 2)) == ", ")
                {
                    sb.Remove(sb.Length - 2, 2);
                }
                sb.Append("]; ");
            }
            if ((sb.ToString().Substring(sb.Length - 2, 2)) == "; ")
            {
                sb.Remove(sb.Length - 2, 2);
            }
            return sb.ToString();
        }
    }
    public class LocalCourse : Course, ILocalCourse
    {
        public LocalCourse(string name, ITeacher teacher, string lab)
            :base(name, teacher)
        {
            this.Lab = lab;
        }

        private string lab;

        public string Lab
        {
            get { return this.lab; }
            set { this.lab = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name+": ");
            sb.Append(base.ToString());
            if (!String.IsNullOrEmpty( this.Lab))
            {
                sb.AppendFormat("; Lab={0}",this.Lab);
            }
            return sb.ToString();
        }
    }
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public OffsiteCourse(string name, ITeacher teacher,string town)
            :base(name, teacher)
        {
            this.Town = town;
        }

        private string town;

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name + ": ");
            sb.Append(base.ToString());
            if (!String.IsNullOrEmpty(this.Town))
            {
                sb.AppendFormat("; Town={0}",this.Town);
            }
            return sb.ToString();
        }
    }
    public class Teacher : ITeacher
    {
        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>().AsEnumerable();
        }
        private string name;
        private List<ICourse> courses;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public IEnumerable<ICourse> Courses
        {
            get { return this.courses.AsEnumerable(); }
            set { this.courses = value.ToList(); }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Teacher: Name={0}; ", this.Name);
            if (this.Courses.Count() != 0)
            {
                sb.Append("Courses=[");
                foreach (var item in this.Courses)
                {
                    sb.Append(item.Name + ", ");
                }
                if ((sb.ToString().Substring(sb.Length - 2, 2)) == ", ")
                {
                    sb.Remove(sb.Length - 2, 2);
                }
                sb.Append("]; ");

            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
    }
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
