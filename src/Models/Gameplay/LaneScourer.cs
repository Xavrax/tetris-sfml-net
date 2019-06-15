using Tetris.Models.Gameplay.Terminos;

namespace Tetris.Models.Gameplay
{
    public class LaneScourer : IScoreResolver
    {
        public LaneScourer(int scoreForLine)
        {
            _scoreForLine = scoreForLine;
        }
        
        public int ClearFullLanesAndGetPoints(bool[,] matrix)
        {
            var result = 0;
            var times = 1;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var count = 0;
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j])
                    {
                        count++;
                    }
                }
                if (count == matrix.GetLength(1))
                {
                    FallRow(i, matrix);
                    result += _scoreForLine * times;
                    times++;
                    i--;
                }
            }
            return result;
        }

        private static void FallRow(int rowNumber, bool[,] matrix)
        {
            for (var i = rowNumber; i > 0 ; i--)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
            }
        }

        private int _scoreForLine;
    }
}