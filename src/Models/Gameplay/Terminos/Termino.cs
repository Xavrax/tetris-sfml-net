using System;
using Tetris.Models.Utilities;
using Sfg = SFML.Graphics;
using Sfs = SFML.System;

namespace Tetris.Models.Gameplay.Terminos
{
    public class Termino : ITermino
    {
        public ushort[] Shapes { get; }
        public Sfg.Color Color { get; }
        public byte Direction { get; private set; }
        public Sfs.Vector2i Position { get; set; }
        public bool Grounded { get; private set; }

        public Termino(ushort[] shapes, Sfg.Color color)
        {
            if (shapes.Length != 4)
            {
                throw new ArgumentException("Too many shape states!");
            }
            
            Shapes = shapes;
            Color = color;
            Direction = 0;
            Grounded = false;
        }

        public void NextDirection(bool[,] matrix)
        {
            var oldDirection = Direction;
            if (++Direction > 3)
            {
                Direction = 0;
            }

            if (IsOccupied(Position, matrix))
            {
                Direction = oldDirection;
            }
        }

        public void EachBlock(Sfs.Vector2i position, Action<int, int> action)
        {
            const int shapeMaxBound = 4;
            var row = 0;
            var col = 0;
            for (var bit = 0x8000; bit > 0; bit = bit >> 1)
            {
                if ((Shapes[Direction] & bit) != 0)
                {
                    action(position.X + col, position.Y + row);
                }

                if (++col == shapeMaxBound)
                {
                    col = 0;
                    row++;
                }
            }
        }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as Termino;
        }

        public bool IsOccupied(Sfs.Vector2i position, bool[,] matrix)
        {
            var result = false;
            EachBlock(position,(x, y) =>
            {
                if (x < 0 || x >= World.WorldBounds.X || y < 0 || y >= World.WorldBounds.Y)
                {
                    result = true;
                }
                else if (matrix[y, x])
                {
                    result = true;
                }
            });
            return result;
        }
        
        public void UpdateCurrent(Sfs.Time dt)
        {
            
          
        }

        public bool Move(EDirection direction, bool[,] matrix)
        {
            var position = Position;
            switch (direction)
            {
                case EDirection.Left:
                    position.X--;
                    break;
                case EDirection.Right:
                    position.X++;
                    break;
                case EDirection.Down:
                    position.Y++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            if (IsOccupied(position, matrix))
            {
                return false;
            }
            
            Position = position;
            return true;
        }
        
        public void Drop(bool[,] matrix)
        {
            if (!Move(EDirection.Down, matrix))
            {
                DropPiece(matrix);
                Grounded = true;
            }
        }

        private void DropPiece(bool[,] matrix)
        {
            EachBlock(Position, (x, y) => { matrix.SetBlocks(x, y, Shapes[Direction]); });
        }
    }
}