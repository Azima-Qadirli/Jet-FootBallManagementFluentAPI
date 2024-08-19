namespace FootballManagement.Exceptions.ChoiceIsNotFoundEx;

public class ChoiceNotFound:Exception
{
    public ChoiceNotFound():base(_message){}
    public ChoiceNotFound(string message):base(message){}
    private static readonly string _message = "Sorry,Choice is not found.";
}