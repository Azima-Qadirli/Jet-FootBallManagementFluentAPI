using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballManagement.Models;

public class Player
{
    [Key]
    public int FormNumber { get; set; }

    [MaxLength(50)]
    public string FullName { get; set; }

    public int NumberOfGoalsScored { get; set; }

    [ForeignKey("Team")]
    public int TeamId { get; set; }

    //[InverseProperty("FootballPlayers")]
    public Team Team { get; set; }
}