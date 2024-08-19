using FootballManagement.AppDbContext;
using FootballManagement.Exceptions.GameIsNotFound;
using FootballManagement.Models;

namespace FootballManagement.Services;

public class GameService
{
    private static Context context = new();

    public void GameAdd(Game game)
    {
        context.Games.Add(game);
        context.SaveChanges();
    }

    public void GameRemove(int TeamId)
    {
        List<Game> games = [..context.Games.Where(g => g.HomeTeamCode == TeamId || g.GuestTeamCode == TeamId)];
        context.Games.RemoveRange(games);
        context.SaveChanges();
    }

    public List<Game> GetAllGames()
    {
        List<Game> games = [..context.Games];
        if (games.Count > 0)
            return games;
        else
        {
            throw new NoGameInSystem("There is no game in system.");
        }
    }

    public Game GetGame(int id)
    {
        Game game = GetAllGames().Find(game => game.Id == id);
        if (game != null)
            return game;
        else
        {
            throw new GameNotFoundEx("No game in system;");
        }
    }
}