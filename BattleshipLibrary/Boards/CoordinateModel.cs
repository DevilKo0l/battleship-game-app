using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Boards
{
    public class CoordinateModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CoordinateModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
