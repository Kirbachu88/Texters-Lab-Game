using System;

namespace TextersLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(55, 25);

            Game.StartGame();

            Game.PlayGame();

            Console.ReadLine();
        }

    }
}
