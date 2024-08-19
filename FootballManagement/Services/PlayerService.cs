using FootballManagement.AppDbContext;
using FootballManagement.Exceptions.PlayerIsNotFound;

namespace FootballManagement.Services;

public class PlayerService
{
    private static Context context = new();

    public void PlayerAdd(Player player)
    {
        context.Players.Add(player);
        context.SaveChanges();
        
    }
    public void Update(int id, string newName)
    {
        Player player = Get(id);
        player.FullName = newName;
        context.Players.Update(player);
        context.SaveChanges();
    }
    public void Update(int id, Player updatedPlayer)
    {
        Player player = Get(id);
        player.NumberOfGoalsScored = updatedPlayer.NumberOfGoalsScored;
        context.Players.Update(player);
        context.SaveChanges();
    }

    public Player Get(int id)
    {
        Player? player = GetAll().Find(player => player.Id == id);
        if (player != null)
        {
            return player;
        }
        else
        {
            throw new PlayerNotFoundEx("There is no player:");
        }
    }

    public List<Player> GetAll()
    {
        List<Player> players = [.. context.Players];
        if (players.Count > 0)
        {
            return players;
        }
        else
        {
            throw new PlayerNotFoundEx("There is no player in system.");
        }
    }

    public void PlayerRemove(int id)
    {
        Player player = Get(id);
        context.Players.Remove(player);
        context.SaveChanges();
    }

    public List<Player> GetByTeam(int teamId)
    {
        List<Player> players = GetAll().FindAll(player => player.TeamId == teamId);
        return players;
    }
}