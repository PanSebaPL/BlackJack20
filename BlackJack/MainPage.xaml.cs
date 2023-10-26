using System.Text;

namespace BlackJack
{
    public partial class MainPage : ContentPage
    {
        public string Cards = "123456789tqkl123456789tqkl123456789tqkl123456789tqkl";
        public string CardColors = "cccccccccccccppppppppppppphhhhhhhhhhhhttttttttttttt";
        int[] CardDeck1 = { };
        string[] CardPath1 = { };
        int[] CardDeck2 = { };
        string[] CardPath2 = { };
        int Rand;
        Random rnd = new Random();
        public MainPage()
        {
            InitializeComponent();
            GenerateDeck();

            


        }
        private void GenerateDeck()
        {
            //Player One Start Deck
            for (int i = 0; i < 2; i++)
            {
                //find new rand;
                char Value = '%';
                int ConvValue = 0;
                char Type = '%';
                while (Value == '%')
                {
                    Rand = rnd.Next(0, Cards.Length);
                    Value = Cards[Rand];
                    Type = CardColors[Rand];
                }
                //Add New Card
                Array.Resize(ref CardDeck1, CardDeck1.Length + 1);
                Array.Resize(ref CardPath1, CardPath1.Length + 1);
                if (Value == 't' || Value == 'q' || Value == 'l' || Value == 'k')
                    ConvValue = 10;
                else
                    int.TryParse(Value.ToString(), out ConvValue);
                CardDeck1[CardDeck1.Length-1]= ConvValue;
                CardPath1[CardPath1.Length - 1] = Value.ToString() + Type.ToString() + ".png";
                Label Card = new Label() { Text = CardPath1[CardPath1.Length - 1] };
                DeckPlayer1.Children.Add(Card);
                //Lock Card
                StringBuilder sb = new StringBuilder(Cards);
                sb[Rand] = '%'; Cards= sb.ToString();
            }
            //PlayerTwo Start Deck
            for (int i = 0; i < 2; i++)
            {
                //find new rand;
                char Value = '%';
                int ConvValue = 0;
                char Type = '%';
                while (Value == '%')
                {
                    Rand = rnd.Next(0, Cards.Length);
                    Value = Cards[Rand];
                    Type = CardColors[Rand];
                }
                //Add New Card
                Array.Resize(ref CardDeck2, CardDeck2.Length + 1);
                Array.Resize(ref CardPath2, CardPath2.Length + 1);
                if (Value == 't' || Value == 'q' || Value == 'l' || Value == 'k')
                    ConvValue = 10;
                else
                    int.TryParse(Value.ToString(), out ConvValue);
                CardDeck2[CardDeck2.Length - 1] = ConvValue;
                CardPath2[CardPath2.Length - 1] = Value.ToString() + Type.ToString() + ".png";
                Label Card = new Label() { Text = CardPath2[CardPath2.Length - 1] };
                DeckPlayer2.Children.Add(Card);
                //Lock Card
                StringBuilder sb = new StringBuilder(Cards);
                sb[Rand] = '%'; Cards = sb.ToString();
            }


        }

        private void OnPlayClicked(object sender, EventArgs e)
        {

        }
        private void OnPassClicked(object sender, EventArgs e)
        {

        }
        private void OnDoubleClicked(object sender, EventArgs e)
        {

        }
    }
}