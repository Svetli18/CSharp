namespace Handball.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Handball.Core.Contracts;
    using Handball.Models;
    using Handball.Models.Contracts;
    using Handball.Models.Players;
    using Handball.Repositories;
    using Handball.Utilities.Messages;

    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }
        //ok
        public string NewTeam(string name)
        {
            ITeam existTeam = this.teams.Models.FirstOrDefault(t => t.Name == name);

            if (existTeam != null)
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, this.teams.GetType().Name);
            }

            ITeam team = new Team(name);

            this.teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, this.teams.GetType().Name);
        }
        //ok
        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = null;

            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            IPlayer testPlayarName = this.players.Models.FirstOrDefault(p => p.Name == name);

            if (testPlayarName != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, this.players.GetType().Name, testPlayarName.GetType().Name);
            }

            this.players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);

        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = this.players.Models.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, this.players.GetType().Name);
            }

            ITeam team = this.teams.Models.FirstOrDefault(t => t.Name == teamName);

            if(team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, this.teams.GetType().Name);
            }

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, player.Name, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, player.Name, player.Team);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teams.Models.FirstOrDefault(t => t.Name == firstTeamName);

            ITeam secondTeam = this.teams.Models.FirstOrDefault(t => t.Name == secondTeamName);

            if (secondTeam.OverallRating < firstTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            ITeam team = this.teams.Models.FirstOrDefault(t => t.Name ==  teamName);

            sb.AppendLine($"***{teamName}***");

            ICollection<IPlayer> sortedPlayers = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            foreach ( var player in sortedPlayers )
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ITeam> sortedTeams = this.teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name)
                .ToList();

            sb.AppendLine("***League Standings***");

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
