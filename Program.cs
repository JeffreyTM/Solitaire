// Global variables
List<string> deck = new List<string>();
List<bool> inDeck = new List<bool>();


// Create, shuffle and display the deck
ResetDeck();
Shuffle();
DisplayDeck();


void DisplayDeck()
{
    foreach (var card in deck)
    {
        if (inDeck[deck.IndexOf(card)])
        {
            Console.WriteLine(ToString(card));
        }
    }
}

void ResetDeck()
{
    deck.Clear();
    inDeck.Clear();
    // Format (0=C, 1=D, 2=H, 3=S): 013 = King of Clubs; 16 = Six of Diamonds
    for (int i = 0; i < 4; i++)
    {
        int count = 1;
        while (count <= 13)
        {
            deck.Add(i + "" + count);
            inDeck.Add(true);
            count++;
        }
    }
}

void Shuffle()
{
    List<string> deckCopy = new List<string>();
    Random random = new Random();
    foreach (var card in deck)
    {
        deckCopy.Add(card);
    }
    //Randomly swaps a card 10,000 times
    for (int i = 0; i < 10000; i++)
    {
        deck[random.Next(deck.Count)] = deckCopy[random.Next(deckCopy.Count)];
    }
    
}

string ToString(string card)
{
    int index = deck.IndexOf(card);
    int face = int.Parse(deck[index].Substring(0, 1));
    int value = int.Parse(deck[index].Substring(1));
    
    string cardString = string.Empty;
    switch (value)
    {
        case 1:
            cardString = "Ace";
            break;
        case 11:
            cardString = "Jack";
            break;
        case 12:
            cardString = "Queen";
            break;
        case 13:
            cardString = "King";
            break;
        default:
            cardString = value.ToString();
            break;
    }

    cardString += " of ";

    switch (face)
    {
        case 0:
            cardString += "Clubs";
            break;
        case 1:
            cardString += "Diamonds";
            break;
        case 2:
            cardString += "Hearts";
            break;
        case 3:
            cardString += "Spades";
            break;
    }

    return cardString;
}



/*Dictionary<String, int[]> cards = new Dictionary<String, int[]>();

cards.Add("Hearts", new int[13]);
cards.Add("Spades", new int[13]);
cards.Add("Clubs", new int[13]);
cards.Add("Diamonds", new int[13]);


foreach (var key in cards.Keys)
{
    for (int i = 0; i < cards[key].Length; i++)
    {
        cards[key][i] = i + 1;
        Console.WriteLine(cards[key][i] + " of " + key);
    }
}
*/
