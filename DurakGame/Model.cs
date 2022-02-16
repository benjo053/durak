namespace DurakGame;

public class Game
{
    public Game(Player player1, Player player2, Pack pack)
    {
        Player1 = player1;
        Player2 = player2;
        Pack = pack;
        List<Card> cards1 = new List<Card>();
        List<Card> cards2 = new List<Card>();
        for (int i = 0; i < 12; i++)
        {
            Card c = pack.Cards[i];
            if(i % 2 == 0)
            {
                cards1.Add(c);
                pack.Cards.Remove(c);
            } else
            {
                cards2.Add(c);
                pack.Cards.Remove(c);
            }
        }
        player1.Hand = cards1;
        player2.Hand = cards2;
        CurrentRound = new Round(Player1, Player2);
    }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Pack Pack { get; set; }
    public Round CurrentRound { get; set; }
}

public class Round
{
    public Round(Player off, Player def)
    {
        Offender = off;
        Defender = def;
    }
    public Player Offender { get; set; }
    public Player Defender { get; set; }
}

public class Player
{
    public Player(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Card> Hand { get; set; }
}

public class Pack
{
    public Pack()
    {
        Cards = new List<Card>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 6; j < 15; j++)
            {
                Cards.Add(new Card((Suit)i, (CardValue)j));
            }
        }
        Shuffle(); // Random cards
        TrumpSuit = Cards[-1].Suit; //Random suit
    }

    public void Shuffle()
    {
        Random r = new Random();
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            Card value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;
        }
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