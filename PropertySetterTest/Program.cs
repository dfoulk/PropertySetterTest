using System;

namespace PropertySetterTest
{
    internal class Program
    {
        public static Test Test { get; set; }

        private static void Main(string[] args)
        {
            Test = new Test();

            var result = Test.Run().Result;

            Console.WriteLine($"Test Result: {result}");

            Console.ReadLine();
        }
    }
}
