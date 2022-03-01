using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Boards;

namespace BattleshipLibrary.Helpers
{
    public static class CellHelper
    {
        public static CellModel At(this List<CellModel> cells, int row, int column)
        {
            return cells.Where(x => x.Coordinate.Row == row && x.Coordinate.Column == column).First();
        }

        //Return all the cells in a defined range
        public static List<CellModel> Range(this List<CellModel> cells, 
                                            int startRow, 
                                            int startCol, 
                                            int endRow, 
                                            int endCol)
        {
            return cells.Where(x => x.Coordinate.Row >= startRow 
                                    && x.Coordinate.Column >= startCol 
                                    && x.Coordinate.Row <= endRow
                                    && x.Coordinate.Column <= endCol).ToList();
        }        
    }
}
