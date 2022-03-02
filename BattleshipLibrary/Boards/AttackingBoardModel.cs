using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;
using BattleshipLibrary.Helpers;

namespace BattleshipLibrary.Boards
{
    public class AttackingBoardModel: BoardModel
    {
        public List<CoordinateModel> GetAvailableRandomCells()
        {
            return Cells.Where(x => x.CellType == CellType.Empty && x.IsRandomAvailable).Select(x => x.Coordinate).ToList();
        }
              

        private List<CellModel> GetNeighborsForCell(CoordinateModel coordinate)
        {
            int row = coordinate.Row;
            int col = coordinate.Column;
            List<CellModel> NeighborsForCell = new List<CellModel>();
            if(col > 1)
            {
                NeighborsForCell.Add(Cells.At(row, col - 1));
            }
            if(row > 1)
            {
                NeighborsForCell.Add(Cells.At(row - 1, col));
            }

            if(col < 10)
            {
                NeighborsForCell.Add(Cells.At(row, col + 1));
            }

            if(row < 10)
            {
                NeighborsForCell.Add(Cells.At(row + 1, col));
            }

            return NeighborsForCell;
        }

        public List<CoordinateModel> GetNeighborsForAttackedCell()
        {
            List<CellModel> NeighBorsForAttackedCell = new List<CellModel>();
            var attackedCells = Cells.Where(x => x.CellType == CellType.Hit);
            foreach(var cell in attackedCells)
            {
                NeighBorsForAttackedCell.AddRange(GetNeighborsForCell(cell.Coordinate).ToList());
            }
            return NeighBorsForAttackedCell.Distinct().Where(x => x.CellType == CellType.Empty).Select(x => x.Coordinate).ToList();
        }
    }
}
