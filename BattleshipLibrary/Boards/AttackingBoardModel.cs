using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;

namespace BattleshipLibrary.Boards
{
    public class AttackingBoardModel: BoardModel
    {
        public List<CoordinateModel> GetAvailableRandomCells()
        {
            return Cells.Where(x => x.CellType == CellType.Empty && x.IsCellAvailable).Select(x => x.Coordinate).ToList();
        }
    }
}
