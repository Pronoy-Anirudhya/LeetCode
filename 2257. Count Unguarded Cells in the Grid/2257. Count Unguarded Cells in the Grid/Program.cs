Console.WriteLine(new Solution().CountUnguarded(4, 6, [[0, 0], [1, 1], [2, 3]], [[0, 1], [2, 2], [1, 4]]));
Console.ReadLine();

public class Solution
{
    private const int GUARDED = 1, WALL = 2, GUARD = 3;
    private readonly List<(int dRow, int dColumn)> directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];
    private int unguardedCellCount;

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        unguardedCellCount = m * n - (guards.Length + walls.Length); //So initially, except for the indices where either there is a GUARD or WALL, every cell is unguarded. Then we will decrement the unguarded cell count as we go and determine the guarded cells in the DFS below
        int[,] grid = new int[m, n];

        for (int index = 0; index < walls.Length; index++)
            grid[walls[index][0], walls[index][1]] = WALL;

        for (int index = 0; index < guards.Length; index++)
            grid[guards[index][0], guards[index][1]] = GUARD;

        for (int index = 0; index < guards.Length; index++)
            for (int direction = 0; direction < directions.Count; direction++)
                DFSGuardVision(grid, guards[index][0] + directions[direction].dRow, guards[index][1] + directions[direction].dColumn, m, n, directions[direction]);

        return unguardedCellCount;
    }

    private void DFSGuardVision(int[,] grid, int row, int column, int m, int n, (int dRow, int dColumn) direction)
    {
        if (row < 0 || row >= m || column < 0 || column >= n || grid[row, column] == WALL || grid[row, column] == GUARD)
            return;

        //If the cell has already been determined as guarded, don't re-decrement the unguarded cell count value
        if (grid[row, column] != GUARDED)
            unguardedCellCount--;

        grid[row, column] = GUARDED;
        row += direction.dRow;
        column += direction.dColumn;
        DFSGuardVision(grid, row, column, m, n, direction);
    }
}