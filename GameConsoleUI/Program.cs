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
           
            PlayerModel player = new PlayerModel("Nguyen");
            player.PrintShips();
            player.PrintBoards();
        }
    }
}
