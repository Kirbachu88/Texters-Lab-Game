using System;
using System.Dynamic;

namespace TextersLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(55, 25);

            Game.StartGame();

            while (!Game.winGame)
            {
                Game.PlayGame();
            }

            Console.ReadLine();
        }

    }
}
