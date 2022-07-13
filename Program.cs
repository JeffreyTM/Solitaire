// Global variables
List<string> cards = new List<string>();
List<bool> inDeck = new List<bool>();


// Create, shuffle and display the deck
ResetCards();
Shuffle();
DisplayDeck();


void DisplayDeck()
{
    foreach (var card in cards)
    {
        if (inDeck[cards.IndexOf(card)] || 1 == 1)
        {
            Console.WriteLine(ToString(card) + " " + inDeck[cards.IndexOf(card)]);

        }
    }
}

void ResetCards()
{
    cards.Clear();
    inDeck.Clear();
    // Format (0=C, 1=D, 2=H, 3=S): 013 = King of Clubs; 16 = Six of Diamonds
    for (int i = 0; i < 4; i++)
    {
        int count = 1;
        while (count <= 13)
        {
            cards.Add(i + "" + count);
            inDeck.Add(true);
            count++;
        }
    }
}

void Shuffle()
{
    List<string> cardsCopy = new List<string>();
    List<bool> inDeckCopy = new List<bool>();
    Random random = new Random();

    for (int i = 0; i < cards.Count; i++)
    {
        cardsCopy.Add(cards[i]);
        inDeckCopy.Add(inDeck[i]);
    }
    //Randomly swaps a card 10,000 times
    for (int i = 0; i < 10000; i++)
    {
        int randomIdx = random.Next(cards.Count);
        int randomIdxCopy = random.Next(cards.Count);
        cards[randomIdx] = cardsCopy[randomIdxCopy];
        inDeck[randomIdx] = inDeckCopy[randomIdxCopy];
    }
    
}

string ToString(string card)
{
    int index = cards.IndexOf(card);
    int face = int.Parse(cards[index].Substring(0, 1));
    int value = int.Parse(cards[index].Substring(1));
    
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
