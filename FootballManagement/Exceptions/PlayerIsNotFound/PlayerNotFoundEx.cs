namespace FootballManagement.Exceptions.PlayerIsNotFound;

public class PlayerNotFoundEx:Exception
{
    private static readonly string _message = "PLayer is  not found.";
    public PlayerNotFoundEx() : base(_message) { }
    public PlayerNotFoundEx(string message) : base(message) { }  
}