using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args) // this is a method called "Main". It is called when the program starts.
        {
            // Basic console program
            // Console.WriteLine ("Hello, this is Uonai.");
            // Console.ReadKey ();
            // Console.WriteLine ("\nMy favorite color is black");
            // Console.ReadKey ();


            // Calculator program
            int num01;
            int num02;

            Console.Write("Type a number to be multiplied: ");
            num01 = Convert.ToInt32 (Console.ReadLine ());
            Console.Write("Type another number: ");
            num02 = Convert.ToInt32(Console.ReadLine ());
            Console.WriteLine("The result is " + num01 * num02);
            Console.ReadKey();
        }
    }
}
