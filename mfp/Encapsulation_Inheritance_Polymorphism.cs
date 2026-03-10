using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mfp
{
    class Person
    {
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age cant be -ve");
                }
                else age = value;
            }
        }
        public virtual void Introduce()
        {
            Console.WriteLine($"Hi my name is {Name} and I am {Age} years old.");
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

    }
    class Student : Person
    {
        public string Grade { get; set; }


        public void Study()
        {
            Console.WriteLine($"{Name} studied and got {Grade} grade");
        }
        public override void Introduce()
        {
            Console.WriteLine($"Hi my name is {Name}, I am {Age} years old and my grade is {Grade}");
        }
        public Student(string name, int age, string grade) : base(name, age)
        {
            this.Grade = grade;
        }
    }
    class Teacher : Person
    {
        public string Subject { get; set; }

        public void Teach()
        {
            Console.WriteLine($"{Name} is Teaching {Subject}");
        }
        public override void Introduce()
        {
            Console.WriteLine($"Hey my name is {Name} and i am {Age} years old and i teach {Subject}");
        }
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            this.Subject = subject;
        }
    }
    internal class Encapsulation_Inheritance_Polymorphism
    {
        public Encapsulation_Inheritance_Polymorphism()
        {
            Student s1 = new Student("Alex", 21, "A");
            Teacher t1 = new Teacher("Rekha", 32, "Math");

            s1.Introduce();
            s1.Study();

            t1.Introduce();
            t1.Teach();
        }
        
    }
}
