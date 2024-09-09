Console.WriteLine(new Solution().LengthOfLongestSubstring("pwwkep"));
Console.ReadLine();

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int longestSubstringLength = 0, currentSubstringLength = 0, left = 0;
        var characterMap = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            var isRepeatingCharacter = characterMap.TryGetValue(s[right], out int repeatingCharacterIndex);

            if (!isRepeatingCharacter || repeatingCharacterIndex < left)
            {
                currentSubstringLength++;

                if (!isRepeatingCharacter)
                    characterMap.Add(s[right], right);
                else
                    characterMap[s[right]] = right;
            }
            else
            {
                longestSubstringLength = Math.Max(longestSubstringLength, currentSubstringLength);
                currentSubstringLength = right - repeatingCharacterIndex;
                characterMap[s[right]] = right;
                left = repeatingCharacterIndex + 1;
            }
        }

        return Math.Max(longestSubstringLength, currentSubstringLength);
    }
}