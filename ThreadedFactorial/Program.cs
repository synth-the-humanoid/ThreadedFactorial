using System;

namespace ThreadedFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            uint value;
            String userInput = "";
            do
            {
                Console.Write("Value to calculate [n >= 0]: ");
                userInput = Console.ReadLine();
            }
            while (!uint.TryParse(userInput, out value));

            Factorial fact = new Factorial(value);
            Console.WriteLine("!{0:D} = {1:S}", value, fact.Result.ToString());
        }
    }
}
