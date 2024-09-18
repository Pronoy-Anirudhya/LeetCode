Console.WriteLine(new Solution().UpdateMatrix([[0, 0, 0], [0, 1, 0], [1, 1, 1]]));
Console.ReadLine();

public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int rowLength = mat.Length, columnLength = mat[0].Length, distance = 0;
        Queue<(int row, int column)> bfs = [];

        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                if (mat[row][column] == 0)
                    bfs.Enqueue((row, column));
                else
                    mat[row][column] = int.MaxValue;
            }
        }

        while (bfs.Count > 0)
        {
            int currentQueueCount = bfs.Count;

            for (int processed = 0; processed < currentQueueCount; processed++)
            {
                (int row, int column) = bfs.Dequeue();

                if (mat[row][column] != 0)
                    mat[row][column] = Math.Min(mat[row][column], distance);

                //Left
                if (row - 1 >= 0 && mat[row - 1][column] == int.MaxValue)
                    bfs.Enqueue((row - 1, column));

                //Right
                if (row + 1 < rowLength && mat[row + 1][column] == int.MaxValue)
                    bfs.Enqueue((row + 1, column));

                //Up
                if (column - 1 >= 0 && mat[row][column - 1] == int.MaxValue)
                    bfs.Enqueue((row, column - 1));

                //Down
                if (column + 1 < columnLength && mat[row][column + 1] == int.MaxValue)
                    bfs.Enqueue((row, column + 1));
            }

            distance++;
        }

        return mat;
    }
}