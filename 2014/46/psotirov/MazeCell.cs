using System;

namespace AlwaysTurnLeft
{
    public enum Wall : byte { Open, Rigid, Unknown };
    public enum Direction : byte { North, West, South, East };

    public static class DirectionExtensions
    {
        public static Direction GetLeft(this Direction dir)
        {
            return (dir == Direction.East) ? Direction.North : ++dir;
        }

        public static Direction GetRight(this Direction dir)
        {
            return (dir == Direction.North) ? Direction.East : --dir;
        }
    }   

    public class MazeCell
    {
        public Wall North { get; set; }
        public Wall South { get; set; }
        public Wall West { get; set; }
        public Wall East { get; set; }

        public MazeCell()
        {
            North = Wall.Unknown;
            South = Wall.Unknown;
            West = Wall.Unknown;
            East = Wall.Unknown;
        }

        public void SetWallState(Direction dir, Wall state)
        {
            switch (dir)
            {
                case Direction.North:
                    this.North = state;
                    break;
                case Direction.West:
                    this.West = state;
                    break;
                case Direction.South:
                    this.South = state;
                    break;
                case Direction.East:
                    this.East = state;
                    break;
                default:
                    break;
            }
        }

        public Wall GetWallState(Direction dir)
        {
            Wall state = Wall.Unknown;

            switch (dir)
            {
                case Direction.North:
                    state = this.North;
                    break;
                case Direction.West:
                    state = this.West;
                    break;
                case Direction.South:
                    state = this.South;
                    break;
                case Direction.East:
                    state = this.East;
                    break;
                default:
                    break;
            }

            return state;
        }

        public string GetCellState()
        {
            int result = ((East == Wall.Open) ? 8 : 0) +
                         ((West == Wall.Open) ? 4 : 0) +
                         ((South == Wall.Open) ? 2 : 0) +
                         ((North == Wall.Open) ? 1 : 0);

            return result.ToString("x1");
        }

        public bool IsUnknown()
        {
            return (East == Wall.Unknown) ||
                   (West == Wall.Unknown) ||
                   (South == Wall.Unknown) ||
                   (North == Wall.Unknown);
        }
    }
}
