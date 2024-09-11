Console.WriteLine(new Solution().CharacterReplacement("JSDSSMESSTR", 2));
Console.ReadLine();

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int maxLength = 0, maxFrequency = 0, left = 0;
        var characterFrequency = new int[26];

        for (int right = 0; right < s.Length; right++)
        {
            characterFrequency[s[right] - 'A']++;
            /* Instead of calculating the max frequency everytime on the array which has O(26) time complexity, we can further optimize it by keeping the historical max frequency like shown below.
             * Here, the trick is, even though we are potentially decreasing the frequency, we are not updating the max frequency since until or unless another max frequency occurs at s[right], it won't affect the historical max length we achieved using the historical max length.
             */
            //maxFrequency = characterFrequency.Max();
            maxFrequency = Math.Max(maxFrequency, characterFrequency[s[right] - 'A']);
            var currentLength = right - left + 1;

            if (currentLength - maxFrequency > k)
            {
                characterFrequency[s[left] - 'A']--;
                left++;
            }

            currentLength = right - left + 1;
            maxLength = Math.Max(maxLength, currentLength);
        }

        return maxLength;
    }
}