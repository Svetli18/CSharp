namespace Telephony
{
    using System;
    using System.Linq;

    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid number!");
            }

            return $"Dialing... {number}";

        }

    }

}
