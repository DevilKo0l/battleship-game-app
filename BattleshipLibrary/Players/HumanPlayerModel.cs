using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;
using BattleshipLibrary.Helpers;
using BattleshipLibrary.Ships;

namespace BattleshipLibrary.Players
{
    public class HumanPlayerModel : PlayerModel
    {
        public HumanPlayerModel()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Name = name;
            GameBoard = new BoardModel();
            AttackingBoard = new AttackingBoardModel();
            Ships = new List<ShipModel>()
            {
                new DestroyerModel(),
                new DestroyerModel(),
                new BattleshipModel()
            };
        }

        public CoordinateModel MissileFire(int row, int col)
        {
            CoordinateModel coords = new CoordinateModel(row, col);
            Console.WriteLine(Name + " says: Firing at " + "(" + coords.Row.ToString() + ", " + coords.Column.ToString() + ")");
            return coords;
        }
    }
}
