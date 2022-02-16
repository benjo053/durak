namespace DurakGame
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game = new DurakGame().StartGame();
        }

        private void Karte_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string[] cardValues = button.Text.Split(",");
            Card c = new Card((Suit) int.Parse(cardValues[0]), (CardValue) int.Parse(cardValues[1]));
            
        }

    }
}