using System;
using System.Net;
using System.Threading.Tasks;

namespace PropertySetterTest
{
    internal class Program
    {
        public static Child Child { get; set; }

        private static void Main(string[] args)
        {
            Child = new Child();

            RunTest().Wait();
        }

        private static async Task RunTest()
        {
            var networkCredential = new NetworkCredential("TestUser", "TestPassword");

            var result = await Child.Test(networkCredential);

            Console.WriteLine($"Test Result: {result}");

            Console.ReadLine();
        }
    }
}
