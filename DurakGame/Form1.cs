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

        //Button, falls man die Karte des Bots nicht schlagen kann
        private void Continue_Click(object sender, EventArgs e)
        {
            game.CurrentRound.Defender.Hand.Cards.Add(game.CurrentRound.CardToBeat);
            game.CurrentRound = new Round(game.CurrentRound.Offender, game.CurrentRound.Defender);
            Card offend = game.CurrentRound.Offender.AutoAttack();
            game.CurrentRound.Defender.Hand.FindAndRemove(offend);
            game.CurrentRound.CardToBeat = offend;
        }

        private void Karte_Click(object sender, EventArgs e)
        {
            if(game.CurrentRound.Offender.Id == 1)
            {
                Button button = (Button)sender;
                string[] cardValues = button.Text.Split(",");
                Card offend = new Card((Suit)int.Parse(cardValues[0]), (CardValue)int.Parse(cardValues[1]));
                game.CurrentRound.Offender.Hand.FindAndRemove(offend);
                game.CurrentRound.CardToBeat = offend;
                Card defend=game.CurrentRound.Defender.AutoBeat(offend, game.TrumpSuit);
                if (defend != null)
                {
                    game.CurrentRound.Defender.Hand.FindAndRemove(defend);
                    //clear table
                    game.CurrentRound = new Round(game.CurrentRound.Defender, game.CurrentRound.Offender);
                    Card offend2 = game.CurrentRound.Offender.AutoAttack();
                    game.CurrentRound.Defender.Hand.FindAndRemove(offend2);
                    //offend2 wird auf den Tisch vom Bot gelegt
                    game.CurrentRound.CardToBeat = offend2;
                }
                else
                {
                    //Bot should take
                    game.CurrentRound.Defender.Hand.Cards.Add(game.CurrentRound.CardToBeat);
                    //clear table
                    game.CurrentRound = new Round(game.CurrentRound.Offender, game.CurrentRound.Defender);
                }
                

            }
            else
            {
                Button button = (Button)sender;
                string[] cardValues = button.Text.Split(",");
                Card defend = new Card((Suit)int.Parse(cardValues[0]), (CardValue)int.Parse(cardValues[1]));
                //if unser Auswahl passt => game.CurrentRound=new Round....
                if((defend.Suit == game.CurrentRound.CardToBeat.Suit && defend.CardValue > game.CurrentRound.CardToBeat.CardValue) || (defend.Suit == game.TrumpSuit && game.CurrentRound.CardToBeat.Suit != game.TrumpSuit))
                {
                    game.CurrentRound.Defender.Hand.FindAndRemove(defend);
                    game.CurrentRound.CardToBeat = null;
                    game.CurrentRound = new Round(game.CurrentRound.Defender, game.CurrentRound.Offender);
                }
                //else MessageBox
                else
                {
                    MessageBox.Show("Ausgewählte Karte schlägt Karte auf dem Tisch nicht.");
                }
            }
            
            
        }

    }
}