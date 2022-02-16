namespace DurakGame;

public class Game
{
    public Game(List<Player>? players = null, Pack? pack = null)
    {
        Players = players ?? new List<Player> { new Player(), new Player() };
        Pack = pack ?? new Pack();
        CurrentRound = new Round();
    }

    public List<Player> Players { get; set; }
    public Pack Pack { get; set; }
    public Round CurrentRound { get; set; }
}

public class Round
{
    public Player Offender { get; set; }
    public Player Defender { get; set; }
}

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Hand Hand { get; set; }
}

public class Hand
{
    public List<Card> Cards { get; set; }
}

public class Pack
{
    public Pack(int numCards = 36)
    {
        Cards = new List<Card>(); // Random cards
        TrumpSuit = Suit.CLUB; //Random suit
    }

    public List<Card> Cards { get; set; }
    public Suit TrumpSuit { get; set; }
}

public class Card
{
    public Card(Suit suit, CardValue cardValue)
    {
        Suit = suit;
        CardValue = cardValue;
    }

    public Suit Suit { get; set; }
    public CardValue CardValue { get; set; }
}

public enum Suit
{
    HEART = 0,
    DIAMOND = 1,
    CLUB = 2,
    SPADE = 3,
}

public enum CardValue
{
    Six = 6,
    Seven,
    Eight,
    Nine,
    Ten,
    Knave,
    Queen,
    King,
    Ass,
}