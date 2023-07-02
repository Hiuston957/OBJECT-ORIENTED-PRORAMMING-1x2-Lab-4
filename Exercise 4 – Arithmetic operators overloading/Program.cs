/*

We can overload various arithmetic operators, such as +, -, * and /, in our classes. This
makes a class more comfortable to use.
Useful links:
• https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
operator -overloading
• https://www.c-sharpcorner.com/article/operator-overloading-in-C-Sharp2/
• https://www.geeksforgeeks.org/c-sharp-operator-overloading/
*/
using System;
namespace Ex_04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base points
            Point p1 = new Point(2.2, 3.4);
            Point p2 = new Point(1.1, 2.1);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            // Test unary operators
            Point p3 = +p1;
            Point p4 = -p1;
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p4.ToString());
            // Test binary operators (number, Point)
            Point p5 = 2.0 * p1;
            Point p6 = p1 * 2.0;
            Point p7 = p1 / 2.0;
            Console.WriteLine(p5.ToString());
            Console.WriteLine(p6.ToString());
            Console.WriteLine(p7.ToString());
            // Test binary operators (Point, Point)
            Point p8 = p1 + p2;
            Point p9 = p1 - p2;
            Console.WriteLine(p8.ToString());
            Console.WriteLine(p9.ToString());
            // Test compound assignment operators
            p3 += p2;
            p4 -= p2;
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p4.ToString());
        }
    }
    /**********************************************************************/
    class Point
    {
        double x, y;
        // Constructor
        public Point(double a, double b)
        {
            x = a;
            y = b;
        }
        // Override ToString, can also write: => base.ToString() + $" ({x}, {y})";
        public override string ToString()
        {
            return base.ToString() + $" ({x}, {y})";
        }
        // Overload unary operators: +Point, -Point
        public static Point operator +(Point p) => p;
        public static Point operator -(Point p) => new Point(-p.x, -p.y);
        // Overload binary operators: number * Point, Point * number, Point / number
        public static Point operator *(double d, Point p) =>
        new Point(d * p.x, d * p.y);
        public static Point operator *(Point p, double d) => d * p;
        public static Point operator /(Point p, double d) => p * (1.0 / d);
        // Overload binary operators: Point1 + Point2, Point1 - Point2
        public static Point operator +(Point p, Point r) =>
        new Point(p.x + r.x, p.y + r.y);
        public static Point operator -(Point p, Point r) => p + (-r);
    }
}