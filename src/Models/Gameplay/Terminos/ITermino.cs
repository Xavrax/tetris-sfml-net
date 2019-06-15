using System;
using Sfs = SFML.System;
using Sfg = SFML.Graphics;

namespace Tetris.Models.Gameplay.Terminos
{
    public interface ITermino : IPrototype, IUpdatable
    {
        Sfs.Vector2i Position { get; set; }
        ushort[] Shapes { get; }
        Sfg.Color Color { get; }
        byte Direction { get; }
        bool Grounded { get; }
        void Drop(bool[,] matrix);
        void NextDirection(bool[,] matrix);
        bool Move(EDirection direction, bool[,] matrix);
        bool IsOccupied(Sfs.Vector2i position, bool[,] matrix);
        void EachBlock(Sfs.Vector2i position, Action<int, int> action);

    }
}