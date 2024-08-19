using System.Linq.Expressions;
using FootballManagement.Exceptions.ChoiceIsNotFoundEx;
using FootballManagement.Models;
using FootballManagement.Services;

namespace FootballManagement.Menu;

public class PlayerMenu
{
    private static readonly string playerMenu= "\t1.Player Add\n" + "\t2.Player Update\n" + "\t3.Player Remove\n" + "\t4.Get All Players\n" + "\t0.Exit\n";

    public static void Menu()
    {
        PlayerService playerService = new();
        TeamService teamService = new();
        bool Continue = true;
        while (Continue)
        {
            Console.Write("Welcome to player menu:");
            Console.WriteLine(playerMenu);
            Console.Write("Enter your choice:");
            int.TryParse(Console.ReadLine()?.Trim(), out int choice);
            try
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            List<Team> teams = teamService.GetAll();
                            Console.Write("Enter fullname:");
                            string fullName = Console.ReadLine()?.Trim();
                            foreach (Team team in teams)
                            {
                                Console.WriteLine(
                                    $"{team.TeamCode} {team.TeamName} Scores:{team.NumberOfWins * 3 + team.NumberOfEquality} Wins:{team.NumberOfWins} Equality;{team.NumberOfEquality} Defeat:{team.NumberOfDefeat}");

                            }

                            Console.Write("Enter id of team;");
                            int.TryParse(Console.ReadLine()?.Trim(), out int teamId);
                            Console.Write("Enter number of form:");
                            int.TryParse(Console.ReadLine()?.Trim(), out int formNumber);
                            teamService.GetTeam(teamId);
                            Player player = new()
                            {
                                FullName = fullName,
                                FormNumber = formNumber,
                                TeamId = teamId
                            };
                            playerService.PlayerAdd(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 2:
                        try
                        {
                            List<Player> players = playerService.GetAll();
                            foreach (Player player in players)
                            {
                                Console.WriteLine(
                                    $"{player.TeamId} {player.FullName} Form;{player.FormNumber} Goals;{player.NumberOfGoalsScored}");
                            }

                            Console.Write("Enter id of player;");
                            int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
                            Player player1 = playerService.Get(playerId);
                            Console.WriteLine($"Enter old name of player;{player1.FullName}");
                            Console.Write("Now enter new name;");
                            string NewName = Console.ReadLine()?.Trim();
                            Player updatedPlayer = new()
                            {
                                FullName = NewName

                            };
                            if (!string.IsNullOrEmpty(NewName))
                            {
                                playerService.Update(playerId, NewName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 3:
                        try
                        {
                            List<Player> players = playerService.GetAll();
                            foreach (Player player in players)
                            {
                                Console.WriteLine(
                                    $"{player.TeamId} {player.FullName} Form;{player.FormNumber} Goals;{player.NumberOfGoalsScored}");
                            }

                            Console.Write("Enter id of playeer to remove;");
                            int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
                            playerService.PlayerRemove(playerId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 4:
                        try
                        {
                            List<Player> players = playerService.GetAll();
                            foreach (Player player in players)
                            {
                                Console.WriteLine(
                                    $"{player.TeamId} {player.FullName} Form;{player.FormNumber} Goals;{player.NumberOfGoalsScored}");

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 0:
                        Continue = false;
                        break;
                    default:
                        throw new ChoiceNotFound("The choice is not found;");

                }

            }
            catch (ChoiceNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}