using System;

namespace PropertySetterTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = new Test();

            var result = test.Run();

            Console.WriteLine($"Test Result: {result}");

            Console.ReadLine();
        }
    }
}
