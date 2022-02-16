namespace DurakGame;

public class DurakGame
{
    public Game StartGame()
    {
        Player me = new Player(1, "Name");
        Player bot = new Player(2, "Bot");
        Pack pack = new Pack();
        Game g = new Game(me, bot, pack);
        return g;
    }
}

// View