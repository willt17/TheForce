using System;

namespace theForce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to blasters!");
            int credits = 100;
            Blasters(ref credits);
        }
        static void Blasters(ref int credits)
        {
            BlastersExplanation();
            int currBet = -1;
            while (currBet == -1)
            {
                currBet = betSize(credits);
            }
            // System.Console.WriteLine(currBet);
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
        static void BlastersExplanation()
        {
            System.Console.WriteLine("Welcome to the blasters game.");
            System.Console.WriteLine("You will be given a stack of 10 cards and shown the value of the first one.");
            System.Console.WriteLine("You must then guess if the next card will be higher or lower in value.");
            System.Console.WriteLine("If you get less than 5 cards correct you lose your bet.");
            System.Console.WriteLine("If ypu get between 5 and 7 cards correct you get your credits back.");
            System.Console.WriteLine("If you get between 7 and 10 cards correct you double your bet.");
            System.Console.WriteLine("If you get all 10 correct you triple your bet.");
        }
    }
}
