using FootballManagement.AppDbContext;
using FootballManagement.Models;
using System.Collections.Generic;
using FootballManagement.Menu;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        MainMenu.Menu();
    }

    public  void EnterFinishedGameResults( int weekNumber, int homeTeamCode, int guestTeamCode, int homeTeamGoals,
        int guestTeamGoals,
        List<(int formNumber, int goals)> homeTeamScores, List<(int formNumber, int goals)> guestTeamScores)
    {
        using (var context = new Context())
        {
            var game = new Game
            {
                WeekNumber = weekNumber,
                HomeTeamCode = homeTeamCode,
                GuestTeamCode = guestTeamCode,
                GoalsOfHomeTeam = homeTeamGoals,
                GoalsOfGuestTeam = guestTeamGoals
            };
            context.Games.Add(game);
            context.SaveChanges();

            //Team-lerin qollarini ayirmaq ucun team-leri update edirik
            var homeTeam = context.Teams.FirstOrDefault(t => t.TeamCode == homeTeamCode);
            var guestTeam = context.Teams.FirstOrDefault(t => t.TeamCode == guestTeamCode);

            if (homeTeam != null && guestTeam != null)
            {
                homeTeam.NumberOfGoalsScored += homeTeamGoals;
                homeTeam.NumberOfGoalsConceded += guestTeamGoals;

                guestTeam.NumberOfGoalsScored += guestTeamGoals;
                guestTeam.NumberOfGoalsConceded += homeTeamGoals;

            }

            if (homeTeamGoals > guestTeamGoals)
            {
                homeTeam.NumberOfWins++;
                guestTeam.NumberOfDefeat++;
            }
            else if (guestTeamGoals > homeTeamGoals)
            {
                guestTeam.NumberOfWins++;
                homeTeam.NumberOfDefeat++;
            }
            else
            {
                homeTeam.NumberOfEquality++;
                guestTeam.NumberOfEquality++;
            }

            context.SaveChanges();
            foreach (var player in homeTeam.Players)
            {
                var footballPlayer = context.Players.Find(player.FormNumber);
                if (footballPlayer != null)
                    footballPlayer.NumberOfGoalsScored += player.NumberOfGoalsScored;
            }

            foreach (var player in guestTeam.Players)
            {
                var footballPlayer = context.Players.Find(player.FormNumber);
                if (footballPlayer != null)
                    footballPlayer.NumberOfGoalsScored += player.NumberOfGoalsScored;
            }

            context.SaveChanges();
        }
    }

    public void ListTeamSituationAndPlayers(string NameOfTeam)
    {
        using (var context = new Context())
        {
            var team = context.Teams.Include(t => t.Players).FirstOrDefault(t => t.TeamName == NameOfTeam);

            if (team != null)
            {
                Console.WriteLine($"Team: {team.TeamCode} {team.TeamName} {team.NumberOfGoalsScored} {team.NumberOfGoalsConceded} {team.NumberOfDefeat}");
                foreach (var player in team.Players.OrderBy(p=>p.FormNumber))
                {
                    Console.WriteLine($"Players: {player.FormNumber} {player.FullName} {player.NumberOfGoalsScored}");
                }
                
            }
            else
            {
                Console.WriteLine("Team is not found.");
            }
            
        }
    }

    public void ListGoalsTable()
    {
        using (var context = new Context())
        {
            var teams = context.Teams.OrderByDescending(t => t.NumberOfWins * 3 + t.NumberOfEquality)
                .ThenByDescending(t => t.NumberOfGoalsScored - t.NumberOfGoalsConceded).ToList();
            foreach (var team in teams)
            {
                var scores = team.NumberOfWins * 3 + team.NumberOfEquality;
                var avegare = team.NumberOfGoalsScored - team.NumberOfGoalsConceded;
                Console.WriteLine($"Team: {team.TeamName} {team.NumberOfEquality} {team.NumberOfDefeat} {team.NumberOfWins} {team.NumberOfGoalsConceded} {team.NumberOfGoalsScored} {scores} {avegare}");
                
            }
            

        }
    }

    public void ListTeamsByScores()
    {
        using (var context = new Context())
        {
            var teams = context.Teams.OrderByDescending(t => t.NumberOfGoalsScored)
                .ThenBy(t => t.NumberOfGoalsConceded).ToList();
            foreach (var team in teams)
            {
                Console.WriteLine($"Team: {team.TeamName} {team.NumberOfGoalsScored} {team.NumberOfGoalsConceded}");
            }
        }
    }

    public void ListPlayersByScores()
    {
        using (var context = new Context())
        {
            var players = context.Players.OrderByDescending(p => p.NumberOfGoalsScored).ToList();
            foreach (var player in players)
            {
                var team = context.Players.Find(player.TeamId);
                Console.WriteLine($"{team.TeamId} {player.FullName} {player.FormNumber} {player.NumberOfGoalsScored}");
            }
        }
    }
}