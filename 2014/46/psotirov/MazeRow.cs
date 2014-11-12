using System;
using System.Collections.Generic;

namespace AlwaysTurnLeft
{
    class MazeRow
    {
        public List<MazeCell> Cells { get; set; }

        public MazeRow()
        {
            Cells = new List<MazeCell>();
        }

        public MazeRow(int cellsNr) : this()
        {
            for (int i = 0; i < cellsNr; i++)
            {
                Cells.Add(new MazeCell());
            }
        }
    }
}
