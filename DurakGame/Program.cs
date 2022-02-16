namespace DurakGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }


    public class Game
    {
        private List<Player> players;
    }

    public class Round
    {
        private Player offender;
        private Player defender;
    }

    public class Player
    {
        private int id;
        private string name;
        private List<Card> hand;
    }

    public class Pack
    {
        private List<Card> cards;
        private Suit trump_suit;
    }

    public class Card
    {
        private Suit suit;
    }

    public enum Suit
    {
        HEART = 0,
        DIAMOND = 1,
        CLUB = 2,
        SPADE

    }
}