using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagement.Models;

public class Game
{
    public int Id { get; set; }
    public int WeekNumber { get; set; }
    [ForeignKey("HomeTeam")]
    public int HomeTeamCode { get; set; }
    [ForeignKey("GuestTeam")]
    public int GuestTeamCode { get; set; }
    
    public int GoalsOfHomeTeam { get; set; }
    public int GoalsOfGuestTeam { get; set; }
    [NotMapped]
    public Team HomeTeam { get; set; }
    [NotMapped]
    public Team GuestTeam { get; set; }
}