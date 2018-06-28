using System;
using System.Threading.Tasks;

namespace PropertySetterTest
{
    public class Test
    {
        private string _storage;

        private string _string;
        public string String
        {
            get
            {
                _string = _storage;

                return _string;
            }
            protected set
            {
                if (value == _string)
                    return;

                // INSERT BREAKPOINT HERE
                _string = value;

                _storage = _string;
            }
        }

        public async Task<bool> Run()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            String = "Test";

            return !string.IsNullOrEmpty(String);
        }
    }
}
