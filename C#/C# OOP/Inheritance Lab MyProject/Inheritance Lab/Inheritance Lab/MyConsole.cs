namespace Farm
{
    using System;

    public class MyConsole : IIoEngineMyConsole
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
