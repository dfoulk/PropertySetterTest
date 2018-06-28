using System;
using System.Net;

namespace PropertySetterTest
{
    public class Child : Parent
    {
        private NetworkCredential _networkCredential;
        public override NetworkCredential NetworkCredential
        {
            get
            {
                _networkCredential = Storage.NetworkCredential;

                if (!string.IsNullOrEmpty(_networkCredential?.Password))
                {
                    try
                    {
                        _networkCredential.Password = RemoveCharacters(_networkCredential.Password);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                        ClearPassword();
                    }
                }

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

                if (!string.IsNullOrEmpty(_networkCredential?.Password))
                {
                    try
                    {
                        _networkCredential.Password = AddCharacters(_networkCredential.Password);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                Storage.NetworkCredential = _networkCredential;
            }
        }

        private string AddCharacters(string str)
        {
            return $"{str}XXX";
        }

        private string RemoveCharacters(string str)
        {
            var charactersToRemove = new[] { 'X' };

            return str.TrimEnd(charactersToRemove);
        }

        public void ClearPassword()
        {
            NetworkCredential = new NetworkCredential(_networkCredential.UserName, string.Empty);
        }
    }
}
