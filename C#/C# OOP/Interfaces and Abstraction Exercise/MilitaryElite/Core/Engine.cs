namespace MilitaryElite.Core
{
    using System;

    using MilitaryElite.IO;
    using MilitaryElite.Contracts;
    using MilitaryElite.Models;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        private ICollection<ISoldier> data;

        private Engine()
        {
            this.data = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            try
            {
                string command;
                while ((command = this.reader.ReadLine()) != "End")
                {
                    string[] commandArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string soldierType = commandArgs[0];

                    string id = commandArgs[1];
                    string firstName = commandArgs[2];
                    string lastName = commandArgs[3];

                    if (soldierType.Equals("Private"))
                    {
                        try
                        {
                            decimal salary = decimal.Parse(commandArgs[4]);

                            Private @private =
                                new Private(id, firstName, lastName, salary);

                            this.data.Add(@private);

                        }
                        catch (Exception e)
                        {
                            this.writer.WriteLine("Private" + e.Message);
                        }

                    }
                    else if (soldierType.Equals("LieutenantGeneral"))
                    {

                        try
                        {
                            decimal salary = decimal.Parse(commandArgs[4]);

                            LieutenantGeneral lieutenantGeneral =
                                new LieutenantGeneral(id, firstName, lastName, salary);

                            foreach (var privateId in commandArgs.Skip(5))
                            {
                                ISoldier @private = this.data
                                    .FirstOrDefault(s => s.Id.Equals(privateId));

                                if (@private != null)
                                {
                                    lieutenantGeneral.AddPrivate(@private);
                                }

                            }
                            
                            this.data.Add(lieutenantGeneral);

                        }
                        catch (Exception e)
                        {
                            this.writer.WriteLine("LieutenantGeneral ->" + e.Message);
                        }

                    }
                    else if (soldierType.Equals("Engineer"))
                    {
                        try
                        {
                            decimal salary = decimal.Parse(commandArgs[4]);
                            string corps = commandArgs[5];

                            Engineer engineer =
                            new Engineer(id, firstName, lastName, salary, corps);
                            IRepair repair;

                            for (int i = 6; i < commandArgs.Length; i += 2)
                            {
                                string partName = commandArgs[i];
                                bool parsedHours =
                                    int.TryParse(commandArgs[i + 1], out int hoursWorked);

                                if (parsedHours)
                                {
                                    repair = new Repair(partName, hoursWorked);

                                    engineer.AddRepair(repair);
                                }

                            }

                            this.data.Add(engineer);
                        }
                        catch (Exception e)
                        {
                            this.writer.WriteLine("Engineer ->" + e.Message);
                        }

                    }
                    else if (soldierType.Equals("Commando"))
                    {
                        try
                        {
                            decimal salary = decimal
                                .Parse(commandArgs[4]);

                            string corps = commandArgs[5];

                            Commando commando =
                            new Commando(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < commandArgs.Length; i += 2)
                            {
                                string missionName = commandArgs[i];
                                string state = commandArgs[i + 1];

                                Mission mission = new Mission(missionName, state);

                                if (0 == mission.State)
                                {
                                    continue;
                                }

                                commando.AddMission(mission);

                            }

                            this.data.Add(commando);

                        }
                        catch (Exception e)
                        {
                            this.writer.WriteLine("Commando ->" + e.Message);
                        }

                    }
                    else if (soldierType.Equals("Spy"))
                    {
                        try
                        {
                            int codeNumber = int.Parse(commandArgs[4]);

                            Spy spy = new Spy(id, firstName, lastName, codeNumber);

                            this.data.Add(spy);

                        }
                        catch (Exception e)
                        {
                            this.writer.WriteLine("Spy ->" + e.Message);
                        }

                    }

                }

                foreach (var soldier in this.data)
                {
                    this.writer.WriteLine(soldier.ToString());
                }

            }
            catch (Exception e)
            {
                this.writer.WriteLine("Engine -> Run" + e.Message);
            }

        }
    }
}
