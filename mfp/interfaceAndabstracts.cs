using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mfp
{
    abstract class Animal
    {
        public string Name { get; set; }
        protected Animal (string name)
        {
            this.Name = name;
        }
        public abstract void MakeSound();
    }
        
    class Dog : Animal {
        public Dog(string name) : base(name) { 
            this.Name = name;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Cat : Animal
    {
        public Cat (string name) : base(name)
        {
            this.Name = name;
        }
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    internal class InterfaceAndAbstracts
    {
        public InterfaceAndAbstracts()
        {
            Dog d1 = new Dog("Leo");
            Cat c1 = new Cat("Snow");

            d1.MakeSound();
            c1.MakeSound();
        }
    }
}
