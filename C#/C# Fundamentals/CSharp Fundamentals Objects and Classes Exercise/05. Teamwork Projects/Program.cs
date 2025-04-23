using System;
using System.Linq;
using System.Collections.Generic;

class Team
{
    public Team(string teamName, string creatorName)
    {
        TeamName = teamName;
        CreatorName = creatorName;
        Members = new List<string>();
    }

    public string TeamName { get; set; }
    public string CreatorName { get; set; }
    public List<string> Members { get; }
    
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] createTeam = Console.ReadLine().Split('-');

            string creator = createTeam[0];
            string teamName = createTeam[1];

            bool IsTeamExist = teams.Any(t => t.TeamName.Equals(teamName));
            bool IsCreatorExist = teams.Any(t => t.CreatorName == creator);

            if (IsTeamExist)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            if (IsCreatorExist)
            {
                Console.WriteLine($"{creator} cannot create another team!");
                continue;
            }

            Team team = new Team(teamName, creator);
            teams.Add(team);
            Console.WriteLine($"Team {teamName} has been created by {creator}!");
        }

        string command;
        while ((command = Console.ReadLine()) != "end of assignment")
        {
            string[] commArguments = command.Split("->");
            string member = commArguments[0];
            string teamName = commArguments[1];
            Team team = teams.Find(t => t.TeamName.Equals(teamName));

            bool IsCreatorExist = teams.Any(t => t.CreatorName == member);
            bool IsMemberExist = teams.Any(t => t.Members.Contains(member));

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (IsCreatorExist || IsMemberExist)
            {
                Console.WriteLine($"Member {member} cannot join team {team.TeamName}!");
                continue;
            }

            team.Members.Add(member);
        }

        List<Team> disbandTeams = teams
            .Where(t => t.Members.Count == 0)
            .OrderBy(t => t.TeamName)
            .ToList();

        teams = teams.Where(t => t.Members.Count > 0)
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.TeamName)
            .ToList();

        foreach (var team in teams)
        {
            Console.WriteLine(team.TeamName);
            Console.WriteLine($"- {team.CreatorName}");
            team.Members.ForEach(m => Console.WriteLine($"-- {m}"));
        }

        Console.WriteLine("Teams to disband:");
        foreach (var team in disbandTeams)
        {
            Console.WriteLine(team.TeamName);
        }
    }
}