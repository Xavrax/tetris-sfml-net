namespace Tetris.Models.Gameplay
{
    public interface IScoreResolver
    {
        int ClearFullLanesAndGetPoints(bool[,] matrix);
    }
}