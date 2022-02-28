using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Boards
{
    public class BoardModel
    {
        public List<CellModel> Cells { get; set; }

        public BoardModel()
        {
            Cells = new List<CellModel>();
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10 ; j++)
                {
                    Cells.Add(new CellModel(i, j));
                }
            }
        }
    }
}
