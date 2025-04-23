namespace Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowseable
    {
        public string Calling(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid number!");
            }

            return $"Calling... {number}";

        }

        public string Browsing(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid URL!");
            }

            return $"Browsing: {url}!";

        }

    }

}
