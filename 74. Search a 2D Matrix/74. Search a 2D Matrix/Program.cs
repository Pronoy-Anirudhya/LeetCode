Console.WriteLine(new Solution().SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 3));
Console.ReadLine();

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var leftRow = 0;
        var rightRow = matrix.Length - 1;
        var leftColumn = 0;
        var rightColumn = matrix[0].Length - 1;

        while (leftRow <= rightRow)
        {
            var midRow = leftRow + ((rightRow - leftRow) / 2);

            if (target >= matrix[midRow][leftColumn] && target <= matrix[midRow][rightColumn])
            {
                while (leftColumn <= rightColumn)
                {
                    var midColumn = leftColumn + ((rightColumn - leftColumn) / 2);
                    var number = matrix[midRow][midColumn];

                    if (target == number)
                        return true;

                    if (target < number)
                        rightColumn = midColumn - 1;
                    else
                        leftColumn = midColumn + 1;
                }

                break;
            }
            else if (target < matrix[midRow][leftColumn])
                rightRow = midRow - 1;
            else
                leftRow = midRow + 1;
        }

        return false;
    }
}