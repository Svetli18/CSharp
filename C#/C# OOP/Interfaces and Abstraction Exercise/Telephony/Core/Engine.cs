namespace Telephony
{
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CallingNumbers();
            BtowsingWebsites();
        }

        private void CallingNumbers()
        {
            string[] numbers = reader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICallable calling = null;

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        calling = new StationaryPhone();
                        this.writer.WriteLine(calling.Calling(number));
                    }
                    else if (number.Length == 10)
                    {
                        calling = new Smartphone();
                        this.writer.WriteLine(calling.Calling(number));
                    }

                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

            }

        }

        private void BtowsingWebsites()
        {
            string[] websites = reader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IBrowseable smartphone = new Smartphone();

            foreach (var website in websites)
            {
                try
                {
                    this.writer.WriteLine(smartphone.Browsing(website));
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

            }

        }

    }

}

