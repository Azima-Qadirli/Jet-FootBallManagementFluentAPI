namespace FootballManagement.Exceptions.TeamIsNotFound;

public class TeamNotFoundEx:Exception
{
    private static readonly string _message = "Team is  not found.";
    public TeamNotFoundEx() : base(_message) { }
    public TeamNotFoundEx(string message) : base(message) { }  
}