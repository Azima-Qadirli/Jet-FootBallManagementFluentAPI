using FootballManagement.Exceptions.ChoiceIsNotFoundEx;

namespace FootballManagement.Menu;

public class MainMenu
{
    private static string menu = "\t1.Team Menu\n" + "\t2.Player Menu\n" + "\t3.Game Menu\n"+"\t0.Exit\n";


    public static void Menu()
    {
        bool IsContinue = true;
        while (IsContinue)
        {
            Console.Write("Welcome to Menu:");
            Console.WriteLine(menu);
            Console.WriteLine("Please,enter your choice:");
            int.TryParse(Console.ReadLine()?.Trim(),out int choice);
            try
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            TeamMenu.Menu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 2:
                        try
                        {
                            PlayerMenu.Menu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 3:
                        try
                        {
                            GameMenu.Menu();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 0:
                        IsContinue = false;
                        break;
                    default:
                        throw new ChoiceNotFound("Sorry,choice is not found:");
                }
            }
            catch (ChoiceNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}