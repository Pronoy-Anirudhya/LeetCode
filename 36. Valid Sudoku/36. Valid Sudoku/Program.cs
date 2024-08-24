var charLine1 = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
var charLine2 = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
var charLine3 = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
var charLine4 = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
var charLine5 = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
var charLine6 = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
var charLine7 = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
var charLine8 = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
var charLine9 = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };

Console.WriteLine(new Solution().IsValidSudoku(new char[][] { charLine1, charLine2, charLine3, charLine4, charLine5, charLine6, charLine7, charLine8, charLine9 } ));
Console.ReadLine();

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        var rowDict = new Dictionary<int, HashSet<char>>();
        var columnDict = new Dictionary<int, HashSet<char>>();
        var squareDict = new Dictionary<string, HashSet<char>>();

        for (int row = 0; row < board.Length; row++)
        {
            rowDict.Add(row, new HashSet<char>());
            var rowSet = rowDict[row];

            for (int col = 0; col < board.Length; col++)
            {
                var value = board[row][col];

                if (value == '.')
                    continue;

                if (!columnDict.ContainsKey(col))
                    columnDict.Add(col, new HashSet<char>());

                var columnSet = columnDict[col];

                var squareDictKey = (row/3).ToString() + (col/3).ToString(); // Since we have 9x9 matrix, there are 9 square of 3x3 squares and each 3x3 square key will be row/3 + col/3 e.g. 1/3 + 2/3 = 00 and 1/1 + 0/3 = 00-> SAME SQUARE so same key 00 

                if (!squareDict.ContainsKey(squareDictKey))
                    squareDict.Add(squareDictKey, new HashSet<char>());

                var squareSet = squareDict[squareDictKey];

                if (rowSet.Contains(value) || columnSet.Contains(value) || squareSet.Contains(value))
                    return false;

                rowSet.Add(value);
                columnSet.Add(value);
                squareSet.Add(value);

                rowDict[row] = rowSet;
                columnDict[col] = columnSet;
                squareDict[squareDictKey] = squareSet;
            }
        }

        return true;
    }
}