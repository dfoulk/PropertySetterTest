using System;
using System.Net;
using System.Threading.Tasks;

namespace PropertySetterTest
{
    public class Parent
    {
        public virtual NetworkCredential NetworkCredential { get; protected set; }

        public virtual async Task<bool> Test(NetworkCredential networkCredential = null)
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
