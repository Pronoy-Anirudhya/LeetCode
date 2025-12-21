Console.WriteLine(new Solution().MinDeletionSize(["ca", "bb", "ac"]));
Console.ReadLine();

public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int minimumDeletedColumnCount = 0, rowLength = strs.Length, columnLength = strs[0].Length;
        bool[] sortedRows = new bool[rowLength]; // Tracks which rows are already sorted. We don't need to compare these rows again. For example, if we have ["abx", "agz", "bgc", "bfc"], after processing column 0 and column 1, we know that row 2 and row 3 are already sorted because "bgc" > "agz" and "bfc" > "agz". So, when we process column 2, we don't need to compare row 2 and row 3 with row 1 again.

        for (int column = 0; column < columnLength; column++)
        {
            bool isColumnUnsorted = false; // Tracks if the current column is unsorted. For example, if we have ["ca", "bb", "ac"], when we process column 0, we find that 'c' > 'b', so the column is unsorted.

            for (int row = 1; row < rowLength; row++)
            {
                int asciiOfCurrentCharacter = strs[row][column] - 'a', asciiOfPreviousCharacter = strs[row - 1][column] - 'a';

                // If the current row is not sorted yet and the current character is less than the previous character, then the column is unsorted.
                if (!sortedRows[row] && asciiOfPreviousCharacter > asciiOfCurrentCharacter)
                {
                    isColumnUnsorted = true; // Mark the column as unsorted.
                    break; // No need to check further rows in this column.
                }
            }

            // If the column is unsorted, we need to delete it. So, we increment the count and move to the next column.
            if (isColumnUnsorted)
            {
                minimumDeletedColumnCount++; // Increment the count of deleted columns.
                continue;
            }

            // If the column is sorted, we need to update the sortedRows array. For each row, if the current character is greater than the previous character, we mark the row as sorted. For example, if we have ["abx", "agz", "bgc", "bfc"], after processing column 0 and column 1, we know that row 2 and row 3 are already sorted because "bgc" > "agz" and "bfc" > "agz".
            for (int row = 1; row < rowLength; row++)
            {
                int asciiOfCurrentCharacter = strs[row][column] - 'a', asciiOfPreviousCharacter = strs[row - 1][column] - 'a';

                if (asciiOfPreviousCharacter < asciiOfCurrentCharacter)
                    sortedRows[row] = true; // Mark the row as sorted.
            }
        }

        return minimumDeletedColumnCount;
    }
}