using FootballManagement.Exceptions.ChoiceIsNotFoundEx;
using FootballManagement.Exceptions.TeamIsNotFound;
using FootballManagement.Models;
using FootballManagement.Services;

namespace FootballManagement.Menu;

public class TeamMenu
{
    private static readonly string teamMenu = "\t1.Team Add.\n" + "\t2.Team Remove.\n" + "\t3.Team Update.\n" +
                                              "\t4.GetAllTeams\n" + "\t0.Exit\n";

    public static void Menu()
    {
        TeamService teamService = new ();
        GameService gameService = new();
        bool IsContinue = true;
        while (IsContinue)
        {
            Console.Write("Welcome to Team menu:");
            Console.WriteLine(teamMenu);
            Console.Write("Please enter your choice:");
            int.TryParse(Console.ReadLine()?.Trim(), out int choice);
            try
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Please,enter name of team;");
                            string TeamName = Console.ReadLine().Trim();
                            if (!string.IsNullOrEmpty(TeamName))
                            {
                                Team team = new()
                                {
                                    TeamName = TeamName
                                };
                                teamService.TeamAdd(team);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 2:
                        try
                        {
                            List<Team> teams = teamService.GetAll();
                            foreach (Team team in teams)
                            {
                                Console.WriteLine(
                                    $"{team.TeamCode} {team.TeamName} Wins:{team.NumberOfWins} Defeats:{team.NumberOfDefeat} Equality: {team.NumberOfEquality}");
                            }

                            Console.WriteLine("Enter id of team to remove:");
                            int.TryParse(Console.ReadLine()?.Trim(), out int TeamId);
                            gameService.GameRemove(TeamId);
                            teamService.TeamRemove(TeamId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 3:
                        try
                        {
                            List<Team> teams = teamService.GetAll();
                            foreach (Team team in teams)
                            {
                                Console.WriteLine(
                                    $"{team.TeamCode}) {team.TeamName} Scores: {team.NumberOfWins * 3 + team.NumberOfEquality} Wins: {team.NumberOfWins} Equality: {team.NumberOfEquality} Defeat: {team.NumberOfDefeat}");
                            }

                            Console.Write("Enter id of team: ");
                            int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
                            Team team1 = teamService.GetTeam(clubId);
                            Console.WriteLine($"Old Teamname: {team1.TeamName}");
                            Console.Write("New TeamName: ");
                            string? newName = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrEmpty(newName))
                            {
                                teamService.TeamUpdate(clubId, newName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 4:
                        try
                        {
                            List<Team> teams = teamService.GetAll();
                            foreach (Team team in teams)
                            {
                                Console.WriteLine(
                                    $"{team.TeamCode} {team.TeamName} Wins:{team.NumberOfWins} Defeat:{team.NumberOfDefeat} Equality:{team.NumberOfEquality} Scores:{team.NumberOfWins * 3 + team.NumberOfDefeat}");

                            }
                        }
                        catch (NoTeamInSystem ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 0:
                        IsContinue = false;
                        break;
                    default:
                        throw new ChoiceNotFound("There is no choice,try again.");
                }
            }
            catch (ChoiceNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}