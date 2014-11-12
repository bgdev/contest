using System;
using System.Collections.Generic;
using System.Text;

namespace AlwaysTurnLeft
{
    public class Maze
    {
        private List<MazeRow> rows;
        private int positionRow; 
        private int positionCol;
        private Direction currentDir; 

        public Maze()
        {
            rows = new List<MazeRow>() { new MazeRow(1) };
            rows[0].Cells[0].North = Wall.Open;
            positionCol = 0;
            positionRow = 0;
            currentDir = Direction.South;
        }

        public void Walk(char move)
        {
            var currentCell = rows[positionRow].Cells[positionCol];

            switch (move)
            {
                case 'L':
                    currentDir = currentDir.GetLeft();
                    break;
                case 'R':
                    // turning right means that front and left walls are rigid 
                    currentCell.SetWallState(currentDir.GetLeft(), Wall.Rigid);
                    currentCell.SetWallState(currentDir, Wall.Rigid);
                    currentDir = currentDir.GetRight();
                    break;
                case 'W':
                    // moving forward means that left wall is open or rigid while front wall is always open
                    if (currentCell.GetWallState(currentDir.GetLeft()) != Wall.Open)
                    {
                        currentCell.SetWallState(currentDir.GetLeft(), Wall.Rigid);
                    }

                    currentCell.SetWallState(currentDir, Wall.Open);

                    // make move and expand maze if necessary
                    switch (currentDir)
	                {
		                case Direction.North:
                            if (positionRow > 0) positionRow--;
                         break;
                        case Direction.West:
                            if (positionCol > 0) positionCol--;
                            else AddNewColumn(true);
                         break;
                        case Direction.South:
                            if (++positionRow == rows.Count) AddNewRow();
                         break;
                        case Direction.East:
                            if (++positionCol == rows[positionRow].Cells.Count) AddNewColumn();
                         break;
 	                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("move", "Illegal move");
            }
        }

        public void CreateExit()
        {
            // simulate walk outside, double turn right and walk inside the maze
            var currentCell = rows[positionRow].Cells[positionCol];
            if (currentCell.GetWallState(currentDir.GetLeft()) != Wall.Open)
            {
                currentCell.SetWallState(currentDir.GetLeft(), Wall.Rigid);
            }

            currentCell.SetWallState(currentDir, Wall.Open);
            currentDir = currentDir.GetRight().GetRight();
        }

        public string GetState()
        {
            StringBuilder result = new StringBuilder();

            foreach (var row in rows)
            {
                foreach (var cell in row.Cells)
                {
                    result.Append(cell.GetCellState());
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private void AddNewColumn(bool atBeginning = false)
        {
            foreach (var item in rows)
            {
                if (atBeginning)
                {
                    item.Cells.Insert(0, new MazeCell());
                    item.Cells[0].East = item.Cells[1].West;
                }
                else
                {
                    int cnt = item.Cells.Count;
                    item.Cells.Add(new MazeCell());
                    item.Cells[cnt].West = item.Cells[cnt - 1].East;
                }
            }
        }

        private void AddNewRow()
        {
            int cnt = rows.Count;
            rows.Add(new MazeRow(rows[cnt - 1].Cells.Count));
            for (int cellIdx = 0; cellIdx < rows[cnt].Cells.Count; cellIdx++)
            {
                rows[cnt].Cells[cellIdx].North = rows[cnt - 1].Cells[cellIdx].South;
            }
        }
    }
}
