/*
We can also overload relational operators == and != in our classes (both must be
overloaded at the same time). Once again, this makes a class more comfortable to use.
IEquatable is a built-in .NET interface. If a class implements Equatable, it must define the
Equals(class) method for comparing two objects of that class. This is different from the
Equals(object) method which overrides how we compare a given class with other objects.
Different ways of casting:
1. (type)object → throws Exception if object cannot be cast into new type
2. object as type → returns null if object cannot be cast into new type
Comparing nulls:
a. if (object == null) → dangerous, uses overloaded ==, may cause exceptions
b. if (object is null) → safer, as it uses direct reference comparison
Useful links:
• https://www.codeproject.com/Articles/20592/Implementing-IEquatable-Properly
• https://www.c-sharpcorner.com/article/operator-overloading-in-C-Sharp2/
• https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statementsexpressions-operators/how-to-define-value-equality-for-a-type
• https://stackoverflow.com/questions/371328/why-is-it-important-to-overridegethashcode-when-equals-method-is-overridden
• https://stackoverflow.com/questions/132445/direct-casting-vs-as-operator
• https://stackoverflow.com/questions/40676426/what-is-the-difference-between-x-isnull-and-x-null
• https://code-maze.com/csharp-difference-between-isnull-and-equality-operators/
*/
using System;
namespace Ex_04_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle() { Radius = 5 };
            Circle c2 = new Circle() { Radius = 5 };
            Circle c3 = new Circle() { Radius = 2 };
            // Test this line before writing the == operator in the Circle class
            // Console.WriteLine(c1 == c2); // false: c1, c2 are different objects
            // Test the relational operators and the Equals method
            Console.WriteLine("c1 == c2 " + (c1 == c2));
            Console.WriteLine("c1 == c3 " + (c1 == c3));
            Console.WriteLine("c1 != c2 " + (c1 != c2));
            Console.WriteLine("c1 != c3 " + (c1 != c3));
            Console.WriteLine("c1 == null " + (c1 == null));
            Console.WriteLine("c1 != null " + (c1 != null));
            Console.WriteLine(c1.Equals(c2));
            Console.WriteLine(c1.Equals("c2")); // not a Circle!
        }
    }
    /**********************************************************************/
    class Circle : IEquatable<Circle>
    {
        public int Radius { get; set; }
        // Compare two Circles, needed for IEquatable
        // If this object is null, the method call will throw an Exception anyway
        public bool Equals(Circle otherCircle)
        {
            if (otherCircle is null) // use "is" here, not "=="
                return false;
            return Radius == otherCircle.Radius;
        }
        // Compare Circle with other object, also useful e.g. for ArrayList.Contains
        public override bool Equals(object obj) => Equals(obj as Circle);
        // This method is useful e.g. for Dictionary keys
        public override int GetHashCode() => Radius.GetHashCode();
        // Overload binary operator Circle1 == Circle2
        public static bool operator ==(Circle a, Circle b)
        {
            if (a is null)
                if (b is null)
                    return true;
                else
                    return false;
            return a.Equals(b);
        }
        // Overload binary operator Circle1 != Circle2
        public static bool operator !=(Circle a, Circle b) => !(a == b);
    }
}