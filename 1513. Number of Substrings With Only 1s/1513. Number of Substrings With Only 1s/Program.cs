Console.WriteLine(new Solution().NumSub("101"));
Console.ReadLine();

public class Solution
{
    public int NumSub(string s)
    {
        const int MODULO = 1000000007;
        long result = 0;
        int left = 0, right = 0;

        // Iterate through the string to find segments of consecutive '1's. Left will increment to the next segment after processing the current one, that is why we use left = right + 1 in the for loop.
        for (; left < s.Length; left = right + 1)
        {
            right = left;
            int current1Count = 0;

            // Move right pointer to count consecutive '1's.
            while (right < s.Length && s[right] == '1')
            {
                current1Count++;
                right++;
            }

            // If no '1's were found, continue to the next segment.
            if (current1Count == 0)
                continue;

            // Calculate the number of substrings formed by current1Count '1's. The formula is n * (n + 1) / 2 to count all substrings. This is called the triangular number formula.
            long currentResult = (long)current1Count * (current1Count + 1) / 2;
            result += currentResult;
            result %= MODULO; // Take modulo at each step to avoid overflow.
        }

        return (int)result;
    }
}