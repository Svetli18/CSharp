namespace FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Team> teams = new HashSet<Team>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = cmd
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string command = cmdArgs[0];
                    string teamName = cmdArgs[1];

                    if (command == "Team")
                    {
                        teams.Add(new Team(teamName));
                    }
                    else if (command == "Add")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        string playerName = cmdArgs[2];
                        int ndurance = int.Parse(cmdArgs[3]);
                        int sprint = int.Parse(cmdArgs[4]);
                        int dribble = int.Parse(cmdArgs[5]);
                        int passing = int.Parse(cmdArgs[6]);
                        int shooting = int.Parse(cmdArgs[7]);

                        team.Add(playerName, ndurance, sprint, dribble, passing, shooting);

                    }
                    else if (command == "Remove")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        string playerName = cmdArgs[2];

                        team.Remove(playerName);

                    }
                    else if (command == "Rating")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        Console.WriteLine($"{team.Name} - {team.Rating()}");

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}