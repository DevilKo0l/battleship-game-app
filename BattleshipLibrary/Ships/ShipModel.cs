using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;

namespace BattleshipLibrary.Ships
{
    public abstract class ShipModel
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }

        public CellType ShipType { get; set; }
        public bool IsSunk => Hits == Size;
        

    }
}
