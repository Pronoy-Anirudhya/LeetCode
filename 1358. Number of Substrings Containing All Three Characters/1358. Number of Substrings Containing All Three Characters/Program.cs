Console.WriteLine(new Solution().NumberOfSubstrings("ababbbc"));
Console.ReadLine();

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int result = 0, left = 0, right = 0;
        Dictionary<char, int> characterCount = new() {
            { 'a', 0 },
            { 'b', 0 },
            { 'c', 0 }
        };

        while (right < s.Length)
        {
            if (characterCount.ContainsKey(s[right]))
                characterCount[s[right]]++;

            //If we get a valid substring after processing the right character, we will keep sliding the left pointer while the window produces a valid substring
            while (IsValidSubstring(characterCount))
            {
                result += 1 + (s.Length - right - 1);//The last 1 is to compensate for the 0-indexed pointers e.g. for length 6, the last index is 5 since it is 0-indexed. That's why the additional 1 decrement.

                //While we are sliding the window by incrementing left pointer, if it's a valid character (a, b, c), we are also decreasing the character count.
                if (characterCount.ContainsKey(s[left]))
                    characterCount[s[left]]--;

                left++;
            }

            right++;
        }

        return result;
    }

    private bool IsValidSubstring(Dictionary<char, int> characterCount)
    {
        return characterCount['a'] > 0 && characterCount['b'] > 0 && characterCount['c'] > 0;
    }
}