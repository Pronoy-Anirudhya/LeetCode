Console.WriteLine(new Solution().MinWindow("aaaaaaaaaaaabbbbbcdd", "abcdd"));
Console.ReadLine();

public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (t.Length > s.Length)
            return string.Empty;
            
        Dictionary<char, int> allowedCharacterFrequency = [];
        int left = 0, minimumWindow = 0, substringStart = 0, substringLength = int.MaxValue;

        for (int index = 0; index < t.Length; index++)
        {
            if (allowedCharacterFrequency.ContainsKey(t[index]))
                allowedCharacterFrequency[t[index]]++;
            else
                allowedCharacterFrequency[t[index]] = 1;
        }

        for (int right = 0; right < s.Length; right++)
        {
            char currentRightCharacter = s[right];

            if (allowedCharacterFrequency.TryGetValue(currentRightCharacter, out int currentRightCharacterFrequency))
            {
                allowedCharacterFrequency[currentRightCharacter] = --currentRightCharacterFrequency;

                if (currentRightCharacterFrequency == 0)
                    minimumWindow++;
            }

            while (minimumWindow == allowedCharacterFrequency.Count)
            {
                int currentSubstringLength = right - left + 1;

                if (currentSubstringLength < substringLength)
                {
                    substringStart = left;
                    substringLength = currentSubstringLength;
                }

                char currentLeftCharacter = s[left++];

                if (allowedCharacterFrequency.TryGetValue(currentLeftCharacter, out int currentLeftCharacterFrequency))
                {
                    if (currentLeftCharacterFrequency == 0)
                        minimumWindow--;

                    allowedCharacterFrequency[currentLeftCharacter] = ++currentLeftCharacterFrequency;
                }
            }
        }

        return substringLength != int.MaxValue ? s.Substring(substringStart, substringLength) : string.Empty;
    }
}