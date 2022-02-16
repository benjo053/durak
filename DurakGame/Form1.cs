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
            if(game.CurrentRound.Offender.Id == 1)
            {
                Button button = (Button)sender;
                string[] cardValues = button.Text.Split(",");
                Card offend = new Card((Suit)int.Parse(cardValues[0]), (CardValue)int.Parse(cardValues[1]));
                game.CurrentRound.Offender.Hand.FindAndRemove(offend);
                Card defend=game.CurrentRound.Defender.AutoBeat(offend, game.TrumpSuit);
                if (defend != null)
                {
                    game.CurrentRound.Defender.Hand.FindAndRemove(defend);
                    //clear table
                    game.CurrentRound = new Round(game.CurrentRound.Defender, game.CurrentRound.Offender);
                    Card offend2 = game.CurrentRound.Offender.AutoAttack();
                    game.CurrentRound.Defender.Hand.FindAndRemove(offend);
                    //offend2 wird auf den Tisch vom Bot gelegt
                    game.CurrentRound.CardToBeat = offend2;
                }
                else
                {
                    //Bot should take
                    //clear table
                }
                

            }
            else
            {
                Button button = (Button)sender;
                string[] cardValues = button.Text.Split(",");
                Card defend = new Card((Suit)int.Parse(cardValues[0]), (CardValue)int.Parse(cardValues[1]));
                game.CurrentRound.Defender.Hand.FindAndRemove(defend);
                //if unser Auswahl passt => game.CurrentRound=new Round....
                //else MessageBox

            }
            
            
        }

    }
}