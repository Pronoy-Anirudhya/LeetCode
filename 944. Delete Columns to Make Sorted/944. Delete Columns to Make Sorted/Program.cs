Console.WriteLine(new Solution().MinDeletionSize(["cba", "daf", "ghi"]));
Console.ReadLine();

public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int deletedColumnCount = 0, rowLength = strs.Length, columnLength = strs[0].Length;

        // Iterate through each column, which is why we have the outer loop for columns.
        for (int column = 0; column < columnLength; column++)
        {
            int asciiOfPreviousCharacter = 0; // Reset for each column. Initialize to 0 to represent 'a' - 1.

            for (int row = 0; row < rowLength; row++)
            {
                int asciiOfCurrentCharacter = strs[row][column] - 'a'; // Get ASCII value relative to 'a'.

                // Compare current character with the previous character in the same column. If not sorted, increment deletedColumnCount and break. Otherwise the order is maintained, so update previous character ascii with current.
                if (asciiOfPreviousCharacter <= asciiOfCurrentCharacter)
                    asciiOfPreviousCharacter = asciiOfCurrentCharacter;
                else
                {
                    deletedColumnCount++;
                    break;
                }
            }
        }

        return deletedColumnCount;
    }
}