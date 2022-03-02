using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Players;
namespace BattleshipLibrary
{
    public class GameControl
    {
        public HumanPlayerModel Player1 { get; set; }
        public ComputerPlayerModel Player2 { get; set; }

        public GameControl()
        {
            Player1 = new HumanPlayerModel();
            Player2 = new ComputerPlayerModel();

            Player1.PrintShips();
            Player2.PrintShips();

            Player1.PrintBoards();
            Player2.PrintBoards();
        }

        public void PlayRound()
        {
            //Each exchange of shots is called a Round.
            //One round = Player 1 fires a shot, then Player 2 fires a shot.
            int[] targetLocation = new int[2];
            Console.Write("Enter your coordination (x y): ");
            var input = Console.ReadLine();
            var data = input.Split(' ');
            targetLocation[0] = int.Parse(data[0]);
            targetLocation[1] = int.Parse(data[1]);

            var coordinates = Player1.MissileFire(targetLocation[0], targetLocation[1]);
            var result = Player2.Report(coordinates);
            Player1.ProcessReport(coordinates, result);

            if (!Player2.HasLost) //If player 2 already lost, we can't let them take another turn.
            {
                coordinates = Player2.MissileFire();
                result = Player1.Report(coordinates);
                Player2.ProcessReport(coordinates, result);
            }
        }

        public void PlayToEnd()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }

            Player1.PrintBoards();
            Player2.PrintBoards();

            if (Player1.HasLost)
            {
                Console.WriteLine(Player2.Name + " has won the game!");
            }
            else if (Player2.HasLost)
            {
                Console.WriteLine(Player1.Name + " has won the game!");
            }
        }
    }
}
