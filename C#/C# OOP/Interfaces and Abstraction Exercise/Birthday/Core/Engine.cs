namespace Birthday.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Birthday.Contracts;
    using Birthday.IO;
    using Birthday.Models;

    public class Engine
    {
        private Reader reader;

        private Writer writer;


        private ICollection<IBirthdate> objects;

        private Engine()
        {
            this.objects = new List<IBirthdate>();
        }

        public Engine(Reader reader, Writer writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string typeName = commandArgs[0];
                    string name = commandArgs[1];

                    if (typeName == "Citizen")
                    {
                        int age = int.Parse(commandArgs[2]);
                        string id = commandArgs[3];

                        int[] dateArgs = commandArgs[4]
                            .Split('/', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        DateTime dateTime = new DateTime(dateArgs[2], dateArgs[1], dateArgs[0]);                        

                        ICitizen citizen = new Citizen(name, age, id, dateTime);

                        this.objects.Add(citizen);

                    }                    
                    else if (typeName == "Pet")
                    {
                        int[] dateArgs = commandArgs[2]
                            .Split('/', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        DateTime dateTime = new DateTime(dateArgs[2], dateArgs[1], dateArgs[0]);

                        IPet pet = new Pet(name, dateTime);

                        this.objects.Add(pet);
                    }

                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

            }

            int year = int.Parse(this.reader.ReadLine());

            foreach (var obj in this.objects)
            {
                DateTime dateTime = obj.DateTime;

                if (dateTime.Year.Equals(year))
                {
                    this.writer.WriteLine($"{dateTime:dd/MM/yyyy}");
                }
            }
        }
    }
}
