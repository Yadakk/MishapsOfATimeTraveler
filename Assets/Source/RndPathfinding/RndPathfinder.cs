using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RndPathfinding
{
    public static class RndPathfinder
    {
        public static Vector2Int[] Vector2IntDirections => new[]
        {
            Vector2Int.right,
            Vector2Int.up,
            Vector2Int.left,
            Vector2Int.down,
        };

        public static List<ICell> Pathfind(
            List<ICell> cellMap, ICell currentCell, ICell targetCell)
        {
            List<ICell> cellPath = new();
            List<ICell> exploredCells = new();
            List<Fork> forks = new();
            int cellsSinceLastFork = 0;

            while (currentCell != targetCell)
            {
                List<ICell> avaliableCells = GetAdjacentCells(cellMap, currentCell.CellPos).Where(
                    cell => !exploredCells.Contains(cell) && cell.IsWalkable).ToList();

                if (avaliableCells.Count == 0)
                {
                    ICell lastFork = forks[^1].cell;

                    if (currentCell != lastFork)
                    {
                        exploredCells.Add(currentCell);
                        currentCell = lastFork;
                        cellPath.RemoveRange(
                            cellPath.Count - cellsSinceLastFork, cellsSinceLastFork);
                        cellsSinceLastFork = 0;
                    }
                    else
                    {
                        cellPath.RemoveRange(
                            cellPath.Count - forks[^1].distanceFromPreviousFork, 
                            forks[^1].distanceFromPreviousFork);
                        forks.RemoveAt(forks.Count - 1);
                        currentCell = lastFork;
                    }
                    continue;
                }
                else if (avaliableCells.Count > 1)
                {
                    forks.Add(new(currentCell, cellsSinceLastFork));
                    cellsSinceLastFork = 0;
                }

                exploredCells.Add(currentCell);
                currentCell = avaliableCells[Random.Range(0, avaliableCells.Count)];
                cellPath.Add(currentCell);
                cellsSinceLastFork++;
            }
            return cellPath;
        }

        public static bool TryPathfind(
            List<ICell> cellMap, ICell currentCell, ICell targetCell, out List<ICell> path)
        {
            path = Pathfind(cellMap, currentCell, targetCell);
            if (path == null) return false;
            return true;
        }

        private static List<ICell> GetAdjacentCells(List<ICell> cellMap, Vector2Int position)
        {
            List<ICell> adjacentCells = new();
            foreach (var direction in Vector2IntDirections)
            {
                Vector2Int adjacentCellPosition = position + direction;
                ICell adjacentCell = cellMap.Find(cell => cell.CellPos == adjacentCellPosition);
                if (adjacentCell == null) continue;
                adjacentCells.Add(adjacentCell);
            }
            return adjacentCells;
        }
    }
}
