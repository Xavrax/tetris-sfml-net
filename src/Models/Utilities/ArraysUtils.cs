namespace Tetris.Models.Utilities
{
    public static class ArraysUtils
    {
        public static void FillArray<T>(this T[,] array, T patern)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = patern;
                }
            }
        }

        public static void SetBlocks(this bool[,] matrix, int x, int y, ushort shape)
        {
            matrix[y, x] = true;
        }
    }
}