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
    public class ComputerPlayerModel : PlayerModel
    {
        public ComputerPlayerModel()
        {
            Name = "CPU";
            GameBoard = new BoardModel();
            AttackingBoard = new AttackingBoardModel();
            Ships = new List<ShipModel>()
            {
                new DestroyerModel(),
                new DestroyerModel(),
                new BattleshipModel()
            };
        }
        

        private CoordinateModel MissileRandomNavigate()
        {
            var availableCells = AttackingBoard.GetAvailableRandomCells();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var cellId = rand.Next(availableCells.Count);
            return availableCells[cellId];
        }

        public CoordinateModel MissileNavigate()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var availableTarget = AttackingBoard.GetNeighborsForAttackedCell();
            var randomTargetID = rand.Next(availableTarget.Count);
            return availableTarget[randomTargetID];
        }

        public CoordinateModel MissileFire()
        {
            var hitTargets = AttackingBoard.GetNeighborsForAttackedCell();
            CoordinateModel coords;
            if (hitTargets.Any())
            {
                coords = MissileNavigate();
            }
            else
            {
                coords = MissileRandomNavigate();
            }
            Console.WriteLine(Name + " says: Firing at " + "(" + coords.Row.ToString() + ", " + coords.Column.ToString() + ")");
            return coords;
        }        
    }
}
