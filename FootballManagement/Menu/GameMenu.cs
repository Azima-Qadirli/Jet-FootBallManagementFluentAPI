using System.Linq.Expressions;
using FootballManagement.Exceptions.ChoiceIsNotFoundEx;
using FootballManagement.Exceptions.PlayerIsNotFound;
using FootballManagement.Models;
using FootballManagement.Services;

namespace FootballManagement.Menu;

public class GameMenu
{
    private static readonly string gameMenu = "\t1.Match Add\n" + "\t2.Get All Matches\n" + "\t0.Exit\n";

    public static void Menu()
    {
        TeamService teamService = new();
        PlayerService playerService = new();
        GameService gameService = new();

        bool IsContinue = true;
        while (IsContinue)
        {
            Console.Write("Welcome to Game menu:");
            Console.WriteLine(gameMenu);
            Console.Write("Please enter your choice: ");
            int.TryParse(Console.ReadLine()?.Trim(), out int choice);
            try
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            List<Player> players = playerService.GetAll();
                            List<Team> teams = teamService.GetAll();
                            foreach (Team team in teams)
                            {
                                Console.WriteLine($"{team.TeamCode} {team.TeamName}");
                            }

                            Console.Write("Enteer week number:");
                            int.TryParse(Console.ReadLine()?.Trim(), out int weekNumber);
                            Console.Write("Enter id of home team:");
                            int.TryParse(Console.ReadLine()?.Trim(), out int homeTeamId);
                            teamService.GetTeam(homeTeamId);
                            Console.Write("Enter id of guest team:");
                            int.TryParse(Console.ReadLine()?.Trim(), out int guestTeamId);
                            teamService.GetTeam(guestTeamId);
                            if (guestTeamId == homeTeamId)
                            {
                                Console.WriteLine("Please,select other teams,you entered same teams.");
                            }
                            else
                            {
                                List<Player> players1 = playerService.GetByTeam(homeTeamId);
                                foreach (Player player in players1)
                                {
                                    Console.WriteLine($"{player.Id} {player.FullName}");
                                }

                                bool IsGame = true;
                                int homeTeamGoals = 0;
                                while (IsGame)
                                {
                                    Console.Write("Enter id of player of home team who scored goal ");
                                    int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
                                    try
                                    {
                                        Player player = playerService.Get(playerId);
                                        Console.Write("Enter number of goals:");
                                        int.TryParse(Console.ReadLine()?.Trim(), out int goals);
                                        homeTeamGoals += goals;
                                        player.NumberOfGoalsScored += goals;
                                        playerService.Update(playerId, player);
                                    }
                                    catch (PlayerNotFoundEx)
                                    {
                                        IsGame = false;
                                    }
                                }

                                List<Player> players2 = playerService.GetByTeam(guestTeamId);
                                foreach (Player player1 in players2)
                                {
                                    Console.WriteLine($"{player1.Id} {player1.FullName}");
                                }

                                bool IsPLay = true;
                                int guestTeamGoals = 0;
                                while (IsPLay)
                                {
                                    Console.Write("Enter id of player of guest team who scored goal:");
                                    int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
                                    try
                                    {
                                        Player player = playerService.Get(playerId);
                                        Console.Write("Enter number of goals:");
                                        int.TryParse(Console.ReadLine()?.Trim(), out int goals);
                                        guestTeamGoals += goals;
                                        player.NumberOfGoalsScored += goals;
                                        playerService.Update(playerId, player);
                                    }
                                    catch (PlayerNotFoundEx)
                                    {
                                        IsPLay = false;
                                    }
                                }

                                Game game = new()
                                {
                                    WeekNumber = weekNumber,
                                    HomeTeamCode = homeTeamId,
                                    GuestTeamCode = guestTeamId,
                                    GoalsOfHomeTeam = homeTeamGoals,
                                    GoalsOfGuestTeam = guestTeamGoals
                                };
                                gameService.GameAdd(game);
                                Team homeTeam = teamService.GetTeam(homeTeamId);
                                Team guestTeam = teamService.GetTeam(guestTeamId);
                                if (homeTeamGoals > guestTeamGoals)
                                {
                                    homeTeam.NumberOfWins++;
                                    guestTeam.NumberOfDefeat++;
                                }
                                else if (homeTeamGoals < guestTeamGoals)
                                {
                                    homeTeam.NumberOfDefeat++;
                                    guestTeam.NumberOfWins++;
                                }
                                else
                                {
                                    homeTeam.NumberOfEquality++;
                                    guestTeam.NumberOfEquality++;
                                }

                                homeTeam.NumberOfGoalsScored += homeTeamGoals;
                                homeTeam.NumberOfGoalsConceded += guestTeamGoals;
                                guestTeam.NumberOfGoalsScored += guestTeamGoals;
                                guestTeam.NumberOfGoalsConceded += homeTeamGoals;
                                teamService.TeamUpdate(homeTeamId, homeTeam);
                                teamService.TeamUpdate(guestTeamId, guestTeam);
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
                            List<Game> games = gameService.GetAllGames();
                            foreach (Game game in games)
                            {
                                Console.WriteLine(
                                    $"{game.Id} WeekNumber:{game.WeekNumber} {teamService.GetTeam(game.HomeTeamCode).TeamName} {game.GoalsOfHomeTeam};{game.GoalsOfGuestTeam}{teamService.GetTeam(game.GuestTeamCode).TeamName}");

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 0:
                        IsContinue = false;
                        break;
                    default:
                        throw new ChoiceNotFound("This choice is not found;");
                }
                

                







            }
            catch (ChoiceNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}