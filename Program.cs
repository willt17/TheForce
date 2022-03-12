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
            int handsWon = 0;
            // CardPrint(deckOfCards);
            int currBet = -1;
            currBet = betSize(credits);
            System.Console.WriteLine(currBet);
            int nextHand = -1;
            while ( nextHand == -1)
            {
                int firstCard = GeneratedRandom();
                int guess = FirstGuess(firstCard, deckOfCards);
                int nextCard = GeneratedRandom();
                bool guessOutcome = GuessCheck(firstCard, nextCard, guess);
                if (guessOutcome == true)
                {
                    handsWon++;
                    swapCards(ref firstCard, ref nextCard);
                    AskContinue(handsWon, ref nextHand);
                }
                else
                {
                    int temp = BetPayout(handsWon, currBet);
                    int tempCredits = (credits + temp);
                    credits = tempCredits;
                    nextHand = 1;
                }
            }

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
        static int FirstGuess(int currCard, string[] deckOfCards)
        {
            System.Console.WriteLine($"Your first card is {deckOfCards[currCard]}");
            int guessInput = -1;
            while (guessInput == -1)
            {
                guessInput = AskGuess();
                return guessInput;
            }
            return guessInput;
        }
        static int AskGuess()
        {
            System.Console.WriteLine("Do you think the next card will be higher or lower?");
            System.Console.WriteLine("Press 1 for higher or 2 for lower.");
            int guessInput = int.Parse(Console.ReadLine());
            return guessInput;

        }
        static bool GuessCheck(int firstCard, int nextCard, int guess)
        {
            bool win = false;
            if (firstCard < nextCard && guess == 1)
            {
                win = true;
                return win;
            }
            else if (firstCard > nextCard && guess == 1)
            {
                win = false;
                return win;
            }
            else if ( firstCard < nextCard && guess == 2)
            {
                win = false;
                return win;
            }
            else
            {
                win = true;
                return win;
            }
        }
        static void swapCards(ref int firstCard, ref int nextCard)
        {
            firstCard = nextCard;
            nextCard = GeneratedRandom();
        }
        static void AskContinue(int handsWon, ref int nextHand)
        {
            System.Console.WriteLine($"You have won {handsWon} would you like to continue?");
            System.Console.WriteLine("Press 1 for yes or 2 for no.");
            int userChoice = 0;
            while ( userChoice == 0)
            {
                userChoice  = int.Parse(Console.ReadLine());
                if (userChoice == 1)
                {
                    nextHand = -1;
                    userChoice = 1;
                }
                else if ( userChoice == 2)
                {
                    nextHand = 0;
                    userChoice = 1;
                }
                else
                {
                    System.Console.WriteLine("That was an invalid choice please try again.");
                }
            }
        }
        static int BetPayout(int handsWon, int currBet)
        {
            if ( handsWon < 5)
            {
                int temp = (currBet * -1);
                return temp;
            }
            else if ( handsWon >= 5 && handsWon < 7)
            {
                int temp = currBet;
                return temp;
            }
            else if ( handsWon >= 7 && handsWon < 10)
            {
                int temp = (currBet * 2);
                return temp;
            }
            else
            {
                int temp = (currBet * 3);
                return temp;
            }
        }
    }   
}
