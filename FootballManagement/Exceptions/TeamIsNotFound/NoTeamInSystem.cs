namespace FootballManagement.Exceptions.TeamIsNotFound;

public class NoTeamInSystem:Exception
{
    public NoTeamInSystem():base(_message){}
    public NoTeamInSystem(string message):base(message){}
    private static readonly string _message = "There is no team in system.";
}