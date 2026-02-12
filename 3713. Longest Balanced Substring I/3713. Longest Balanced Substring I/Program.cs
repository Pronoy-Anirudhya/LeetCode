Console.WriteLine(new Solution().LongestBalanced("zzabccy"));
Console.ReadLine();

public class Solution
{
    public int LongestBalanced(string s)
    {
        int longestBalancedSubstringLength = 0;

        for (int left = 0; left < s.Length; left++)
        {
            int[] characterFrequency = new int[26]; // Store frequency of each character from 'a' to 'z'

            for (int right = left; right < s.Length; right++)
            {
                int currentCaharacterAscii = s[right] - 'a';
                characterFrequency[currentCaharacterAscii]++;

                // Check if the current substring is balanced. If yes, update the longest length.
                if (isBalancedSubstring(characterFrequency))
                    longestBalancedSubstringLength = Math.Max(longestBalancedSubstringLength, right - left + 1);
            }
        }

        return longestBalancedSubstringLength;
    }

    private static bool isBalancedSubstring(int[] characterFrequency)
    {
        int expectedFrequency = 0;

        for (int index = 0; index < characterFrequency.Length; index++)
        {
            // Skip characters that are not present in the substring
            if (characterFrequency[index] == 0)
                continue;

            // Set the expected frequency based on the first character found. In the else case, compare the frequency of the current character with the expected frequency. When a mismatch is found, return false.
            if (expectedFrequency == 0)
                expectedFrequency = characterFrequency[index];
            else if (characterFrequency[index] != expectedFrequency)
                return false;
        }

        return true; // All characters have the same frequency
    }
}