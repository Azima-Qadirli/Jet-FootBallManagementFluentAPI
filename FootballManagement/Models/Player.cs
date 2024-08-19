using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballManagement.Models;

public class Player
{
    public int Id { get; set; }
    [Range(1,99)]
    public int FormNumber { get; set; }

    [MaxLength(50)]
    public string FullName { get; set; }

    public int NumberOfGoalsScored { get; set; }

    [ForeignKey("Team")]
    public int TeamId { get; set; }
    public Team Team { get; set; }
}