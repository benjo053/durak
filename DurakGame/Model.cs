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
        TrumpSuit = Pack.Cards[-1].Suit; //Random suit
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
        player1.Hand.Cards = cards1;
        player2.Hand.Cards = cards2;
        CurrentRound = new Round(Player1, Player2);
    }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Pack Pack { get; set; }
    public Round CurrentRound { get; set; }
    public Suit TrumpSuit { get; set; }
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
    public Card CardToBeat { get; set; }

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
    public Hand Hand { get; set; }

    public Card AutoBeat(Card c, Suit trump)
    {
        foreach(Card card in Hand.Cards)
        {
            if(card.Suit == c.Suit && card.CardValue > c.CardValue)
            {
                return card;
            }else if(card.Suit == trump && c.Suit != trump)
            {
                return card;
            }
        }
        return null;
    }

    public Card AutoAttack()
    {
        Card temp = Hand.Cards[0];
        foreach (Card card in Hand.Cards)
        {
            if (card.CardValue < temp.CardValue)
            {
                temp = card;
            }
        }
        return temp;
    }
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
        foreach (Card el in Cards)
        {
            if (el.Suit == TrumpSuit)
            {
                el.CardValue = (CardValue)((int)el.CardValue * 100);
            }
        }

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

public class Hand
{
    public Hand(List<Card> c)
    {
        Cards = c;
    }
    public List<Card> Cards { get; set; }
    public void FindAndRemove( Card c)
    {
        foreach(Card card in Cards)
        {
            if(card.CardValue == c.CardValue && card.Suit == c.Suit)
            {
                Cards.Remove(card);
                break;
            }
        }
    }
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
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Knave = 11,
    Queen = 12,
    King = 13,
    Ass = 14,
    Six_Trump = 600,
    Seven_Trump = 700,
    Eight_Trump = 800,
    Nine_Trump = 900,
    Ten_Trump = 1000,
    Knave_Trump = 1100,
    Queen_Trump = 1200,
    King_Trump = 1300,
    Ass_Trump = 1400
}