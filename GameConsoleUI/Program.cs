using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary;

namespace GameConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            int player1Wins = 0, player2Wins = 0;

            Console.WriteLine("How many games do you want to play?");
            var numGames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numGames; i++)
            {
                GameControl game = new GameControl();
                game.PlayToEnd();
                if (game.Player1.HasLost)
                {
                    player2Wins++;
                }
                else
                {
                    player1Wins++;
                }
            }

            Console.WriteLine("Player 1 Wins: " + player1Wins.ToString());
            Console.WriteLine("Player 2 Wins: " + player2Wins.ToString());
            Console.ReadLine();
        }
    }
}
