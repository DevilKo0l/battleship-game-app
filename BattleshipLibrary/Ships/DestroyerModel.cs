using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;

namespace BattleshipLibrary.Ships
{
    class DestroyerModel:ShipModel
    {
        public DestroyerModel()
        {
            Name = "Destroyer";
            Size = 4;
            ShipType = CellType.Destroyer;
        }
    }
}
