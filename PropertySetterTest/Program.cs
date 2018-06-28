using System;
using System.Threading.Tasks;

namespace PropertySetterTest
{
    internal class Program
    {
        public static Test Test { get; set; }

        private static void Main(string[] args)
        {
            Test = new Test();

            RunTest().Wait();
        }

        private static async Task RunTest()
        {
            var result = await Test.Run();

            Console.WriteLine($"Test Result: {result}");

            Console.ReadLine();
        }
    }
}
