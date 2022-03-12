using System;

namespace theForce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to blasters!");
            int credits = 100;
            TheForce(ref credits);
        }
        static void TheForce(ref int credits)
        {
            string[] deckOfCards = new string[12];
            DeckGenerator(deckOfCards);
            TheForceExplanation();
            // CardPrint(deckOfCards);
            int currBet = -1;
            while (currBet == -1)
            {
                currBet = betSize(credits);
            }
            System.Console.WriteLine(currBet);
            int currCard = GeneratedRandom();
            FirstGuess(currCard, deckOfCards);
        }
        static int betSize(int credits)
        {
            int temp = 0;
            System.Console.WriteLine("How much would you like to bet?");
            temp = int.Parse(Console.ReadLine());
            if (temp <= credits)
            {
                return temp;
            }
            else
            {
                System.Console.WriteLine("You don't have enough credits for that bet.");
                temp = -1;
                return temp;
            }

        }
        static void TheForceExplanation()
        {
            System.Console.WriteLine("Welcome to the blasters game.");
            System.Console.WriteLine("You will be given a stack of 10 cards and shown the value of the first one.");
            System.Console.WriteLine("You must then guess if the next card will be higher or lower in value.");
            System.Console.WriteLine("If you get less than 5 cards correct you lose your bet.");
            System.Console.WriteLine("If ypu get between 5 and 7 cards correct you get your credits back.");
            System.Console.WriteLine("If you get between 7 and 10 cards correct you double your bet.");
            System.Console.WriteLine("If you get all 10 correct you triple your bet.");
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            System.Console.WriteLine("\n");
        }
        static void DeckGenerator(string[] deckOfCards)
        {
            deckOfCards[0] = "Ace";
            deckOfCards[1] = "Two";
            deckOfCards[2] = "Three";
            deckOfCards[3] = "Four";
            deckOfCards[4] = "Five";
            deckOfCards[5] = "Six";
            deckOfCards[6] = "Seven";
            deckOfCards[7] = "Eight";
            deckOfCards[8] = "Nine";
            deckOfCards[9] = "Joker";
            deckOfCards[10] = "Queen";
            deckOfCards[11] = "King";

        }
        // static void CardPrint(string[] deckOfCards)
        // {
        //     for (int i = 0; i < deckOfCards.Length; i++)
        //     {
        //         System.Console.WriteLine(deckOfCards[i]);
        //     }
        // }
        static int GeneratedRandom()
        {
            Random rnd = new Random();
            int result = rnd.Next(11);
            return result;
        }
        static void FirstGuess(int currCard, string[] deckOfCards)
        {
            System.Console.WriteLine($"Your first card is {deckOfCards[currCard]}");
            int guessInput = -1;
            while (guessInput == -1)
            {
                guessInput = AskGuess();
            }
        }
        static int AskGuess()
        {
            System.Console.WriteLine("Do you think the next card will be higher or lower?");
            System.Console.WriteLine("Press 1 for higher or 2 for lower.");
            int guessInput = int.Parse(Console.ReadLine());
            return guessInput;

        }
    }   
}
