using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;

namespace BattleshipLibrary.Ships
{
    class BattleshipModel : ShipModel
    {
        public BattleshipModel()
        {
            Name = "Battleship";
            Size = 5;
            ShipType = CellType.Battleship;
        }
    }
}
