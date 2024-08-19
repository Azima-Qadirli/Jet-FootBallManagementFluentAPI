namespace FootballManagement.Exceptions.PlayerIsNotFound;

public class NoPlayerInSystem:Exception
{
    private static readonly string _message = "There is no player in system";
    public NoPlayerInSystem() : base(_message) { }
    public NoPlayerInSystem(string message) : base(message) { }  
}