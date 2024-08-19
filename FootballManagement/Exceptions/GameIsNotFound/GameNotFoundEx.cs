namespace FootballManagement.Exceptions.GameIsNotFound;

public class GameNotFoundEx:Exception
{
    private static readonly string _message = "Game is  not found.";
    public GameNotFoundEx() : base(_message) { }
    public GameNotFoundEx(string message) : base(message) { }  
}