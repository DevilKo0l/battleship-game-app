using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BattleshipLibrary.Helpers;

namespace BattleshipLibrary.Boards
{
    public enum CellType
    {
        [Description("O")]
        Empty,

        [Description("B")]
        Battleship,
        
        [Description("D")]
        Destroyer,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss,
    }
    public class CellModel
    {
        public CoordinateModel Coordinate { get; set; }
        public CellType CellType { get; set; }

        public CellModel(int row, int column)
        {
            Coordinate = new CoordinateModel(row, column);
        }

        public string Status => CellType.GetAttributeOfType<DescriptionAttribute>().Description;

        public bool IsAttacked => CellType == CellType.Battleship || CellType == CellType.Destroyer;

        public bool IsCellAvailable => Coordinate.Row % 2 == 0 && Coordinate.Column % 2 == 0 ||
                                       Coordinate.Row%2 == 1 && Coordinate.Column % 2 == 1;
        
    }
        
}
