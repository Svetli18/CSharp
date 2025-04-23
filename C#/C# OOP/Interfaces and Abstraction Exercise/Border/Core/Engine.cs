namespace Border.Core
{
    using System;
    using Border.IO;
    using Border.Models;
    using Border.Contracts;

    public class Engine : IEngine
    {
        private Reader reader;

        private Writer writer;


        private ICollection<IId> objects;

        private Engine()
        {
            this.objects = new List<IId>();
        }

        public Engine(Reader reader, Writer writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string cmd;
            while ((cmd = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (cmdArgs.Length == 3)
                    {
                        string name = cmdArgs[0];
                        int age = int.Parse(cmdArgs[1]);
                        string id = cmdArgs[2];

                        bool isFaund = false;

                        foreach (var currObj in this.objects)
                        {
                            if (currObj.GetType().Name == "Citizen")
                            {
                                Citizen currCitizen = (Citizen)Convert
                                    .ChangeType(currObj, currObj.GetType());

                                if (currCitizen.Name == name &&
                                    currCitizen.Age == age &&
                                    currCitizen.Id == id)
                                {
                                    this.objects.Remove(currCitizen);
                                    isFaund = true;
                                    continue;
                                }
                            }
                        }

                        if (isFaund)
                        {
                            continue;
                        }

                        ICitizen citizen = new Citizen(name, age, id);

                        this.objects.Add(citizen);

                    }
                    else if (cmdArgs.Length == 2)
                    {
                        string model = cmdArgs[0];
                        string id = cmdArgs[1];

                        bool isFaund = false;

                        foreach (var currObj in this.objects)
                        {
                            if (currObj.GetType().Name == "Robot")
                            {
                                Robot currRobot = (Robot)Convert
                                    .ChangeType(currObj, currObj.GetType());

                                if (currRobot.Model == model &&
                                    currRobot.Id == id)
                                {
                                    this.objects.Remove(currRobot);
                                    isFaund = true;
                                    break;
                                }
                            }
                        }

                        if (isFaund)
                        {
                            continue;
                        }

                        IRobot robot = new Robot(model, id);

                        this.objects.Add(robot);
                    }

                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

            }

            cmd = this.reader.ReadLine();

            foreach (var obj in this.objects)
            {
                string objId = obj.Id;

                string objLastSymbols = string
                    .Join("", objId.Skip(objId.Length - cmd.Length));

                if (objLastSymbols.Equals(cmd))
                {
                    this.writer.WriteLine(objId);
                }
            }
        }
    }
}