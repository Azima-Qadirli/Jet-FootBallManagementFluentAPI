using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagement.Models;

public class Team
{
    [Key]
    public int TeamCode { get; set; }
    [MaxLength(50)]
    public string TeamName { get; set; }
    public int NumberOfWins { get; set; }
    public int NumberOfEquality { get; set; }
    public int NumberOfDefeat { get; set; }
    public int NumberOfGoalsScored { get; set; }
    public int NumberOfGoalsConceded { get; set; }
    public ICollection<Player> Players { get; set; }
    
    [InverseProperty("HomeTeam")]
    public ICollection<Game> HomeGames { get; set; }
    [InverseProperty("GuestTeam")]
    public ICollection<Game>GuestGames { get; set; }
    
}