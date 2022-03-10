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
            int currBet = -1;
            while (currBet == -1)
            {
                currBet = betSize(credits);
            }
            System.Console.WriteLine(currBet);
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
    }
}
