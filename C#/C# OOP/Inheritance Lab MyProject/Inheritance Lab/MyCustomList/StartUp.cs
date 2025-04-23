namespace MyCustomList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>();

            MyCustomList<string> myList = new MyCustomList<string>();

            myList.Add("az");
            myList.Add("marti");
            myList.Add("iliqn");
            myList.Add("gogo");

            //myList;

            myList.AddLast("mama");

            myList.RemoveAt(3);

            var test = myList.MyRandomList;

            

            Console.WriteLine(string.Join(' ', list));
        }
    }
}
