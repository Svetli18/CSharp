namespace FoodShortage.Core
{
    using System;

    using FoodShortage.Contracts;
    using FoodShortage.IO;
    using FoodShortage.Models;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        private Dictionary<string, IPerson> data;

        private Engine()
        {
            this.data = new Dictionary<string, IPerson>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            AddObjectsInData();
            PrintTotalFoodInfo();
        }

        private void PrintTotalFoodInfo()
        {
            try
            {
                string currName;
                while ((currName = this.reader.ReadLine()) != "End")
                {
                    if (this.data.ContainsKey(currName))
                    {
                        var currObject = this.data[currName];

                        currObject.BuyFood();
                    }
                }

                int totalFood = 0;

                if (this.data.Any())
                {
                    foreach (var kvp in this.data)
                    {
                        totalFood += kvp.Value.Food;
                    }
                }

                this.writer.WriteLine(totalFood.ToString());
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }

        private void AddObjectsInData()
        {
            try
            {
                int n = int.Parse(reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] objArgs = this.reader.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = objArgs[0];
                    int age = int.Parse(objArgs[1]);

                    if (objArgs.Length == 4)
                    {
                        string id = objArgs[2];

                        int[] dateArgs = objArgs[3]
                            .Split('/', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        int day = dateArgs[0];
                        int month = dateArgs[1];
                        int year = dateArgs[2];

                        DateTime dateTime = new DateTime(year, month, day);

                        if (!this.data.ContainsKey(name))
                        {
                            this.data[name] = new Citizen(name, age, id, dateTime);
                        }
                    }
                    else if (objArgs.Length == 3)
                    {
                        string group = objArgs[2];

                        if (!this.data.ContainsKey(name))
                        {
                            this.data[name] = new Rebel(name, age, group);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}
