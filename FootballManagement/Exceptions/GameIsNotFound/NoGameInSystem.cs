namespace FootballManagement.Exceptions.GameIsNotFound;

public class NoGameInSystem:Exception
{
    private static readonly string _message = "There is no game in system.";
    public NoGameInSystem() : base(_message) { }
    public NoGameInSystem(string message) : base(message) { }  
}