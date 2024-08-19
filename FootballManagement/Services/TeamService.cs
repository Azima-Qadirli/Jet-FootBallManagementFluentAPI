using System.Diagnostics;
using FootballManagement.AppDbContext;
using FootballManagement.Exceptions.TeamIsNotFound;
using FootballManagement.Models;

namespace FootballManagement.Services;

public class TeamService
{
    private static Context context = new();

    public void TeamAdd(Team team)
    {
        context.Teams.Add(team);
        context.SaveChanges();
    }

    public Team GetTeam(int id)
    {
        Team team = GetAll().Find(team => team.TeamCode == id);
        if (team != null)
            return team;
        else
        {
            throw new TeamNotFoundEx("There is no team.");
        }

    }

    public List<Team> GetAll()
    {
        List<Team> teams = [..context.Teams];
        if (teams.Count > 0)
            return teams;
        else
        {
            throw new NoTeamInSystem("Team is not found.");
        }
    }

    public void TeamRemove(int id)
    {
        Team team = GetTeam(id);
        context.Teams.Remove(team);
        context.SaveChanges();
    }

    public void TeamUpdate(int id, string newTeamName)
    {
        Team team = GetTeam(id);
        team.TeamName = newTeamName;
        context.Teams.Update(team);
        context.SaveChanges();
    }

    public void TeamUpdate(int id, Team UpdatedTeam)
    {
        Team team = GetTeam(id);
        team.NumberOfWins = UpdatedTeam.NumberOfWins;
        team.NumberOfDefeat = UpdatedTeam.NumberOfDefeat;
        team.NumberOfEquality = UpdatedTeam.NumberOfEquality;
        team.NumberOfGoalsConceded = UpdatedTeam.NumberOfGoalsConceded;
        team.NumberOfGoalsScored = UpdatedTeam.NumberOfGoalsScored;
        context.Teams.Update(team);
        context.SaveChanges();
    }
}