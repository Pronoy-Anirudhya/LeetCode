new Solution().Solve([['O', 'X', 'X', 'O', 'X'], ['X', 'O', 'O', 'X', 'O'], ['X', 'O', 'X', 'O', 'X'], ['O', 'X', 'O', 'O', 'O'], ['X', 'X', 'O', 'X', 'O']]);
Console.ReadLine();

public class Solution
{
    public void Solve(char[][] board)
    {
        //If both row & column is smaller in length than 2, then we can't form any region 
        if (board.Length <= 2 || board[0].Length <= 2)
            return;

        //If there are any O in any of the 4 edges in the board, then any subsequent connected O's will not be eligible to form a region. That's why here we are first checking all the O's in the edge and marking there conected O's inside the board (not on the edge) as N to specify that they can't form a region.
        for (int row = 0; row < board.Length; row++)
            for (int column = 0; column < board[row].Length; column++)
                if (row == 0 || row == board.Length - 1 || column == 0 || column == board[row].Length -1)
                    if (board[row][column] == 'O')
                        BFS(board, row, column);

        //After we have determined which of the O's inside the board can't be part of any region, we can now just make all the O's inside the board as X since they will definitely be able to form a region. While doing so, we will also revert the N's as O's which we had marked earlier since they can't form any region.
        for (int row = 1; row < board.Length - 1; row++)
        {
            for (int column = 1; column < board[row].Length - 1; column++)
            {
                if (board[row][column] == 'O')
                    board[row][column] = 'X';

                if (board[row][column] == 'N')
                    board[row][column] = 'O';

            }
        }
    }

    private void BFS(char[][] board, int row, int column)
    {
        Queue<(int row, int column)> bfs = [];
        (int dx, int dy)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        bfs.Enqueue((row, column));

        while (bfs.Count > 0)
        {
            var grid = bfs.Dequeue();

            foreach (var direction in directions)
            {
                (int nextRow, int nextColumn) = (grid.row + direction.dx, grid.column + direction.dy);

                //Either out of bound or on the edge (so even if it's 0 we can't consider it to form a region)
                if (nextRow <= 0 || nextRow >= board.Length - 1 || nextColumn <= 0 || nextColumn >= board[0].Length - 1)
                    continue;

                //Can't be part of a region, either X or N
                if (board[nextRow][nextColumn] == 'X' || board[nextRow][nextColumn] == 'N')
                    continue;

                bfs.Enqueue((nextRow, nextColumn));
                board[nextRow][nextColumn] = 'N'; //Marking the O as N so specify they can't be part of a region
            }
        }
    }
}