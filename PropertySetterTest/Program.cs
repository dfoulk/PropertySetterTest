using System;
using System.Net;
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
            var networkCredential = new NetworkCredential("TestUser", "TestPassword");

            var result = await Test.Run(networkCredential);

            Console.WriteLine($"Test Result: {result}");

            Console.ReadLine();
        }
    }
}
