using System;
using System.Net;

namespace Test
{
    public static class Storage
    {
        private static NetworkCredential _networkCredential;

        public static NetworkCredential NetworkCredential
        {
            get
            {
                Console.WriteLine($"Retrieving credentials ({_networkCredential?.UserName}:{_networkCredential?.Password})");

                return _networkCredential;
            }
            set
            {
                _networkCredential = value;

                Console.WriteLine($"Saving credentials ({_networkCredential?.UserName}:{_networkCredential?.Password})");
            }
        }
    }
}
