/*When a class is derived from another, it can hide or override the base class methods. This
means providing a new method which replaces the old one.
Hiding (as shown with Method 1 below) is usually considered a bad practice and should be
avoided. It’s better to use overriding instead (as shown with Method 2 below). This is
because, when casting a derived class to a base class, overriding still allows us to use the
method from the derived class, with more specific behaviour.
Useful links:
1.https://stackoverflow.com/questions/3838553/overriding-vs-method-hiding
2.https://www.dotnettricks.com/learn/csharp/understanding-virtual-override-and-newkeyword-in-csharp
*/
using System;
namespace Ex_04_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Person:");
            Person p = new Person();
            p.Method1();
            p.Method2();
            Console.WriteLine("Worker:");
            Worker w = new Worker();
            w.Method1();
            w.Method2();
            Console.WriteLine("Person from Worker:");
            Person n = w; // cast a Worker to Person
            n.Method1();
            n.Method2();
        }
    }
    /**********************************************************************/
    class Person
    {
        public void Method1()
        {
            Console.WriteLine("Person Method 1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("Person Method 2\n");
        }
    }
    /**********************************************************************/
    class Worker : Person
    {
        // Method hiding - not recommended
        public new void Method1()
        {
            Console.WriteLine("Worker Method 1");
        }
        // Method overriding - recommended
        public override void Method2()
        {
            Console.WriteLine("Worker Method 2\n");
        }
    }
}