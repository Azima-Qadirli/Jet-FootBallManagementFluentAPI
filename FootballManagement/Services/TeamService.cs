using System.Diagnostics;
using FootballManagement.AppDbContext;
using FootballManagement.Exceptions.TeamIsNotFound;
using FootballManagement.Models;

namespace FootballManagement.Services;

public class TeamService
{
    private readonly Context _context = new();

    public void TeamAdd(Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
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
        // List<Team> teams = [.._context.Teams];
        List<Team> teams = _context.Teams.ToList();
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
        _context.Teams.Remove(team);
        _context.SaveChanges();
    }

    public void TeamUpdate(int id, string newTeamName)
    {
        Team team = GetTeam(id);
        team.TeamName = newTeamName;
        _context.Teams.Update(team);
        _context.SaveChanges();
    }

    public void TeamUpdate(int id, Team UpdatedTeam)
    {
        Team team = GetTeam(id);
        team.NumberOfWins = UpdatedTeam.NumberOfWins;
        team.NumberOfDefeat = UpdatedTeam.NumberOfDefeat;
        team.NumberOfEquality = UpdatedTeam.NumberOfEquality;
        team.NumberOfGoalsConceded = UpdatedTeam.NumberOfGoalsConceded;
        team.NumberOfGoalsScored = UpdatedTeam.NumberOfGoalsScored;
        _context.Teams.Update(team);
        _context.SaveChanges();
    }
}