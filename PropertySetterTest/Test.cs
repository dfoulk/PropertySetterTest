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

                // INSERT BREAKPOINT HERE and follow these steps:
                // 1) Once in place: Run the app and let it hit this breakpoint
                // 2) Once this breakpoint is hit: Hit F10 once to step to the next line
                // 3) IMPORTANT: Examine 'value' and 'this > _networkCredential' in the 'Locals' tab (_networkCredential != value for some reason?)
                // 4) Hit 'Continue' to finish executing the app
                // 5) Notice that 'Program.RunTest() > Child.Test()' returns 'false'; indicating a test failure
                // 6) Disable all breakpoints
                // 7) Run the app again
                // 8) Notice that 'Program.RunTest() > Child.Test()' returns 'true'; indicating a test success
                // 9) Try to wipe the confused look off your face
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
