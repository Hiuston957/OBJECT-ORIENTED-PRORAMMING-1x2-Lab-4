/*
You can define your own class conversions. The implicit ones don’t require you to write
explicitly the new type, as opposed to the explicit ones.
Useful links:
• https://betterprogramming.pub/casting-in-c-b0cdb21e6048
• https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/userdefined-conversion-operators
*/using System;
namespace Ex_04_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new Money(1.5, "PLN");
            double d = m1; // implicit conversion Money -> double
            Money m2 = (Money)2.5; // explicit conversion double -> Money
            Console.WriteLine(d);
            Console.WriteLine($"{m2.Amount} {m2.Currency}");
        }
    }
    /**********************************************************************/
    class Money
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        // Constructor
        public Money(double d, string s)
        {
            Amount = d;
            Currency = s;
        }
        // Implicit and explicit conversions (can use regular methods, too)
        public static implicit operator double(Money m) => m.Amount;
        public static explicit operator Money(double d) => new Money(d, "EUR");
    }
}