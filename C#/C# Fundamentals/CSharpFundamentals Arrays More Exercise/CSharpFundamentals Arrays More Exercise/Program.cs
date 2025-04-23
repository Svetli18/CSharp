namespace Encrypt
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            int[] nameValue = new int[n];


            for (int i = 0; i < n; i++)
            {
                string currentName = Console.ReadLine();

                int sum = 0;

                names[i] = currentName;

                for (int j = 0; j < currentName.Length; j++)
                {
                    char currChar = currentName[j];

                    if (currChar == 'A' || currChar == 'E' || currChar == 'I' || currChar == 'O' || currChar == 'U' ||
                        currChar == 'a' || currChar == 'e' || currChar == 'i' || currChar == 'o' || currChar == 'u')
                    {
                        sum += currChar * currentName.Length;
                    }
                    else
                    {
                        sum += currChar / currentName.Length;
                    }

                }

                nameValue[i] = sum;

            }

            nameValue = nameValue.OrderBy(x => x).ToArray();

            foreach (var element in nameValue)
            {
                Console.WriteLine(element);
            }

        }
    }
}