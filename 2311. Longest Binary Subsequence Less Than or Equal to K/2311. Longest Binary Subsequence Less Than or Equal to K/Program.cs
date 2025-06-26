Console.WriteLine(new Solution().LongestSubsequence("1001010", 5));
Console.ReadLine();

public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int longestSubsequenceLength = 0, length = s.Length - 1;
        double binaryValue = 0;
        bool isBinaryValueLessThanK = true;

        for (int index = length; index >= 0; index--)
        {
            // If the current character is '0', it can always be included in the subsequence.
            if (s[index] == '0')
            {
                longestSubsequenceLength++;
                continue;
            }

            // If the binary value exceeds k, we stop considering further '1's.
            if (!isBinaryValueLessThanK)
                continue;

            // If the current character is '1', calculate its binary value contribution.
            int pow = length - index;
            var currentBinaryValue = Math.Pow(2, pow);
            binaryValue += currentBinaryValue;

            // If the binary value is less than or equal to k, we can include this '1' in the subsequence. Otherwise, we stop considering further '1's.
            if (binaryValue <= k)
                longestSubsequenceLength++;
            else
                isBinaryValueLessThanK = false;
        }

        return longestSubsequenceLength;
    }
}