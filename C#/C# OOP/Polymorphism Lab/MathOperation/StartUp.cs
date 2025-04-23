namespace Operations
{
    using System;
    using Operations.IO;
    using Operations.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MathOperations math = new MathOperations();

            IWriter<int> result1 = new Writer<int>();
            IWriter<double> result2 = new Writer<double>();
            IWriter<decimal> result3 = new Writer<decimal>();

            result1.WriteLine(math.Add(2, 3));
            result2.WriteLine(math.Add(2.2, 3.3, 5.5));
            result3.WriteLine(math.Add(2.2m, 3.3m, 4.4m));
        }
    }
}