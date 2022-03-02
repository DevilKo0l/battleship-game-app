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
    public enum ShootingReport
    {
        Hit,
        Miss
    }
    public class PlayerModel
    {
        public string Name { get; set; }
        public BoardModel GameBoard { get; set; }
        public AttackingBoardModel AttackingBoard { get; set; }

        public List<ShipModel> Ships { get; set; }

        public bool HasLost => Ships.All(x => x.IsSunk);

        public void PrintBoards()
        {
            Console.WriteLine(Name + "\n");
            Console.WriteLine("My Ocean                                                              Rada\n"); ;
            Console.WriteLine("[ ]  [1]  [2]  [3]  [4]  [5]  [6]  [7]  [8]  [9]  [10]" + "                " + "[1]  [2]  [3]  [4]  [5]  [6]  [7]  [8]  [9]  [10]\n");
            string[] alphaBet = { "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]", "[10]" };
            for (int row = 0; row < 10; row++)
            {
                Console.Write(alphaBet[row] + "  ");
                for (int myCol = 0; myCol < 10; myCol++)
                {
                    Console.Write(GameBoard.Cells.At(row, myCol).Status + "  ");
                }
                Console.Write("               ");
                for (int attackingCol = 0; attackingCol < 10; attackingCol++)
                {
                    Console.Write(AttackingBoard.Cells.At(attackingCol, attackingCol).Status + "  ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public void PrintShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                bool isContinue = true;
                while (isContinue)
                {
                    var startCol = rand.Next(1, 11);
                    var startRow = rand.Next(1, 11);
                    int endRow = startRow, endCol = startCol;
                    var direction = rand.Next(1, 101) % 2;

                    List<int> cellNumbers = new List<int>();

                    if (direction == 0)
                    {
                        for (int i = 0; i < ship.Size; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ship.Size; i++)
                        {
                            endCol++;
                        }
                    }

                    if (endRow > 10 || endCol > 10)
                    {
                        isContinue = true;
                        continue;
                    }

                    var ModifiedCells = GameBoard.Cells.Range(startRow, startCol, endRow, endCol);
                    Console.Clear();
                    if (ModifiedCells.Any(x => x.IsCellOccupied))
                    {
                        isContinue = true;
                        continue;
                    }
                    foreach (var cell in ModifiedCells)
                    {

                        cell.CellType = ship.CellType;
                    }
                    isContinue = false;
                }
            }
        }

        public ShootingReport Report(CoordinateModel coords)
        {
            var cell = GameBoard.Cells.At(coords.Row, coords.Column);
            if (!cell.IsCellOccupied)
            {
                Console.WriteLine(Name + " says:\"Miss!\"");
                return ShootingReport.Miss;
            }

            var ship = Ships.First(x => x.CellType == cell.CellType);
            ship.Hits++;
            Console.WriteLine(Name + "says: \"Hit!\"");
            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }
            return ShootingReport.Hit;
        }

        public void ProcessReport(CoordinateModel coords, ShootingReport result)
        {
            var cell = AttackingBoard.Cells.At(coords.Row, coords.Column);
            switch (result)
            {
                case ShootingReport.Hit:
                    cell.CellType = CellType.Hit;
                    break;

                default:
                    cell.CellType = CellType.Miss;
                    break;
            }
        }

    }

}
