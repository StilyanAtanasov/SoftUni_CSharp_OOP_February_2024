namespace _03._Cards;

// The solution requires both classes in one file!

internal class Program
{
    public static void Main(string[] args)
    {
        string[] inputData = Console.ReadLine()!.Split(", ");
        List<Card> cards = new List<Card>();
        foreach (string rawCard in inputData)
        {
            try
            {
                string[] rawCardData = rawCard.Split();
                string face = rawCardData[0];
                char suit = Convert.ToChar(rawCardData[1]);
                cards.Add(new Card(face, suit));
            }
            catch (FormatException)
            {
                Console.WriteLine(Card.CardException.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(string.Join(' ', cards));
    }
}

public class Card
{
    private static readonly string[] Faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private static readonly Dictionary<char, char> Suits = new()
    {
        // The following UTF characters are not supported by default
        {'S', '\u2660' },
        {'H', '\u2665' },
        {'D', '\u2666' },
        {'C', '\u2663' }
    };

    public static readonly ArgumentException CardException = new("Invalid card!");

    private readonly string _face = null!;
    private readonly char _suit;

    public Card(string face, char suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => _face;
        private init
        {
            if (!Faces.Contains(value)) throw CardException;
            _face = value;
        }
    }

    public char Suit
    {
        get => _suit;
        private init
        {
            if (!Suits.ContainsKey(value)) throw CardException;
            _suit = Suits[value];
        }
    }

    public override string ToString() => $"[{Face}{Suit}]";
}