using System;

namespace leadsquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the game:");

            CardGame game = new CardGame();
            game.Start();

            Console.ReadKey();
        }

    }
}
