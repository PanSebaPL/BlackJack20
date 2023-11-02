using System.Text;

namespace BlackJack
{
    public partial class MainPage : ContentPage
    {
        public string Cards = "123456789tl";
        public string CardColors = "ccccccccccc";
        //qk123456789tqkl123456789tqkl123456789tqkl
        //ccppppppppppppphhhhhhhhhhhhttttttttttttt
        int[] CardDeck1 = { };
        string[] CardPath1 = { };
        int[] CardDeck2 = { };
        string[] CardPath2 = { };
        int cardCount = 0;
        bool Player1Pass = false;
        bool Player2Pass = false;
        int Rand;
        int Player1Sum = 0;int Player2Sum = 0;
        Random rnd = new Random();
        Random Computer = new Random();
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
                    Rand = rnd.Next(0, Cards.Length-1);
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
                CardPath1[CardPath1.Length - 1] = "c"+Value.ToString() + Type.ToString() + ".png";
                Player1Sum += ConvValue;
                Image Card = new Image() { Source = CardPath1[CardPath1.Length - 1] };
                cardCount++;
                DeckPlayer1.Children.Add(Card);
                //Lock Card
                StringBuilder sb = new StringBuilder(Cards);
                sb[Rand] = '%'; Cards= sb.ToString();
            }
            Player1Count.Text=Player1Sum.ToString();
            SemanticScreenReader.Announce(Player1Count.Text);
            //PlayerTwo Start Deck
            for (int i = 0; i < 2; i++)
            {
                //find new rand;
                char Value = '%';
                int ConvValue = 0;
                char Type = '%';
                while (Value == '%')
                {
                    Rand = rnd.Next(0, Cards.Length-1);
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
                CardPath2[CardPath2.Length - 1] = "c"+Value.ToString() + Type.ToString() + ".png";
                Player2Sum += ConvValue;
                Image Card = new Image() { Source = CardPath2[CardPath2.Length - 1] };
                cardCount++;
                DeckPlayer2.Children.Add(Card);
                //Lock Card
                StringBuilder sb = new StringBuilder(Cards);
                sb[Rand] = '%'; Cards = sb.ToString();
            }
            Player2Count.Text = Player2Sum.ToString();
            SemanticScreenReader.Announce(Player2Count.Text);

        }

        private void OnPlayClicked(object sender, EventArgs e)
        {
            if (cardCount>=10)
                Player1PlayButton.IsEnabled = false;
            else if (Cards.Distinct().Count() > 1) {
                //Player 1 Card Pick
                char Value = '%';
                int ConvValue = 0;
                char Type = '%';
                if (Cards.Distinct().Count() == 1)
                {

                }
                else
                {
                    while (Value == '%' && !(Cards.Distinct().Count() <= 1))
                    {
                        Rand = rnd.Next(0, Cards.Length - 1);
                        Value = Cards[Rand];
                        Type = CardColors[Rand];
                    }
                }
                //Add New Card
                Array.Resize(ref CardDeck1, CardDeck1.Length + 1);
                Array.Resize(ref CardPath1, CardPath1.Length + 1);
                if (Value == 't' || Value == 'q' || Value == 'l' || Value == 'k')
                    ConvValue = 10;
                else
                    int.TryParse(Value.ToString(), out ConvValue);
                CardDeck1[CardDeck1.Length - 1] = ConvValue;
                CardPath1[CardPath1.Length - 1] = "c" + Value.ToString() + Type.ToString() + ".png";
                Player1Sum += ConvValue;
                Image Card = new Image() { Source = CardPath1[CardPath1.Length - 1] };
                cardCount++;
                DeckPlayer1.Children.Add(Card);
                //Lock Card
                StringBuilder sb = new StringBuilder(Cards);
                sb[Rand] = '%'; Cards = sb.ToString();
                Player1Count.Text = Player1Sum.ToString();
                SemanticScreenReader.Announce(Player1Count.Text);
                if (cardCount >= 10)
                    Player1PlayButton.IsEnabled = false;
                else if (!Player2Pass)
                {
                    //Decide a move
                    if (Player2Sum < 10) {
                        Rand = Computer.Next(0, 100);
                        if(Rand<10)
                            Player2Pass = true;
                    }
                    else if (Player2Sum >= 10 & Player2Sum < 17) {
                        Rand = Computer.Next(0, 100);
                        if (Rand < 20)
                            Player2Pass = true;
                    }
                    else if (Player2Sum >= 17&&Player2Sum<19) {
                        Rand = Computer.Next(0, 100);
                        if (Rand < 90)
                            Player2Pass = true;
                    }
                    else if (Player2Sum >= 19)
                        Player2Pass = true;
                    if (!Player2Pass) {
                        //find new rand;
                        Value = '%';
                        ConvValue = 0;
                        Type = '%';
                        while (Value == '%' && !(Cards.Distinct().Count() <= 1))
                        {
                            Rand = rnd.Next(0, Cards.Length - 1);
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
                        CardPath2[CardPath2.Length - 1] = "c" + Value.ToString() + Type.ToString() + ".png";
                        Player2Sum += ConvValue;
                        Card = new Image() { Source = CardPath2[CardPath2.Length - 1] };
                        cardCount++;
                        DeckPlayer2.Children.Add(Card);
                        //Lock Card
                        sb = new StringBuilder(Cards);
                        sb[Rand] = '%'; Cards = sb.ToString();
                        Player2Count.Text = Player2Sum.ToString();
                        SemanticScreenReader.Announce(Player2Count.Text);
                    }
                }
            }
            else
            {
                OnPassClicked(sender, e);
            }
            //Computer Card pick

        }
        private void OnPassClicked(object sender, EventArgs e)
        {
            char Value = '%';
            int ConvValue = 0;
            char Type = '%';
            Player1Pass = true;
            Player1PlayButton.IsEnabled = false;
            if (!Player2Pass)
            {
                //Decide a move
                if (Player2Sum < 10)
                {
                    Rand = Computer.Next(0, 100);
                    if (Rand < 10)
                        Player2Pass = true;
                    
                }
                else if (Player2Sum >= 10 & Player2Sum < 17)
                {
                    Rand = Computer.Next(0, 100);
                    if (Rand < 20)
                        Player2Pass = true;
                }
                else if (Player2Sum >= 17 && Player2Sum < 19)
                {
                    Rand = Computer.Next(0, 100);
                    if (Rand < 90)
                        Player2Pass = true;
                }
                else if (Player2Sum >= 19)
                    Player2Pass = true;
                if (!Player2Pass)
                {
                    //find new rand;
                    Value = '%';
                    ConvValue = 0;
                    Type = '%';
                    while (Value == '%' && !(Cards.Distinct().Count() <= 1))
                    {
                        Rand = rnd.Next(0, Cards.Length - 1);
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
                    CardPath2[CardPath2.Length - 1] = "c" + Value.ToString() + Type.ToString() + ".png";
                    Player2Sum += ConvValue;
                    Image Card = new Image() { Source = CardPath2[CardPath2.Length - 1] };
                    cardCount++;
                    DeckPlayer2.Children.Add(Card);
                    //Lock Card
                    StringBuilder sb = new StringBuilder(Cards);
                    sb[Rand] = '%'; Cards = sb.ToString();
                    Player2Count.Text = Player2Sum.ToString();
                    SemanticScreenReader.Announce(Player2Count.Text);
                }
                OnPassClicked(sender, e);
            }
            else
            {
                if (Player1Sum <= 21 && Player2Sum <= 21)
                {
                    int ScoreA = 21 - Player1Sum;
                    int ScoreB = 21 - Player2Sum;
                    if(ScoreA> ScoreB)
                    {
                        Player1Count.Text = "Lost";
                        Player2Count.Text = "Won";
                    }
                    else if (ScoreA < ScoreB)
                    {
                        Player1Count.Text = "Won";
                        Player2Count.Text = "Lost";
                    }
                    else
                    {
                        Player1Count.Text = "Draw";
                        Player2Count.Text = "Draw";
                    }
                }
                else if (Player1Sum > 21 && Player2Sum <= 21)
                {
                    Player1Count.Text = "Lost";
                    Player2Count.Text = "Won";
                }
                else if(Player1Sum <= 21 && Player2Sum > 21)
                {
                    Player1Count.Text = "Won";
                    Player2Count.Text = "Lost";
                }
                else if(Player1Sum > 21 && Player2Sum > 21)
                {
                    int ScoreA = 21 - Player1Sum;
                    int ScoreB = 21 - Player2Sum;
                    if (ScoreA < ScoreB)
                    {
                        Player1Count.Text = "Lost";
                        Player2Count.Text = "Won";
                    }
                    else if (ScoreA > ScoreB)
                    {
                        Player1Count.Text = "Won";
                        Player2Count.Text = "Lost";
                    }
                    else
                    {
                        Player1Count.Text = "Draw";
                        Player2Count.Text = "Draw";
                    }
                }
                SemanticScreenReader.Announce(Player1Count.Text);
                SemanticScreenReader.Announce(Player2Count.Text);
            }
        }
        private void OnDoubleClicked(object sender, EventArgs e)
        {

        }
    }
}