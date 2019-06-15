using Tetris.Models.Gameplay.Terminos;

namespace Tetris.Models.Gameplay
{
    public interface IWorld : IUpdatable
    {
        ITermino CurrentPiece { get; }
        bool[,] Matrix { get; }
        bool WorldEnded { get; }

    }
}