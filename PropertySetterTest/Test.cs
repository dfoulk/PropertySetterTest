using System;
using System.Net;
using System.Threading.Tasks;

namespace PropertySetterTest
{
    public class Test
    {
        private NetworkCredential _networkCredential;
        public NetworkCredential NetworkCredential
        {
            get
            {
                _networkCredential = Storage.NetworkCredential;

                return _networkCredential;
            }
            protected set
            {
                if (value == _networkCredential)
                    return;

                // INSERT BREAKPOINT HERE
                _networkCredential = value;

                Storage.NetworkCredential = _networkCredential;
            }
        }

        public async Task<bool> Run(NetworkCredential networkCredential = null)
        {
            networkCredential = networkCredential ?? NetworkCredential;

            await Task.Delay(TimeSpan.FromSeconds(1));

            var isValid = !string.IsNullOrEmpty(networkCredential?.UserName) &&
                          !string.IsNullOrEmpty(networkCredential?.Password);

            if (isValid)
                NetworkCredential = networkCredential;

            var isSuccessful = !string.IsNullOrEmpty(NetworkCredential?.UserName) &&
                               !string.IsNullOrEmpty(NetworkCredential?.Password);

            return isSuccessful;
        }
    }
}
