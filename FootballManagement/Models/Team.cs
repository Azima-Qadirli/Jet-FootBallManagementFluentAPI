using System.ComponentModel.DataAnnotations;

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
    
    public ICollection<Player>Players { get; set; }
    //public ICollection<Game>HomeGames { get; set; }
    //public ICollection<Game>GuestGames { get; set; }
    
}