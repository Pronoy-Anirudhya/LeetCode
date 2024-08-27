Console.WriteLine(new Solution().FrequencySort("cccaaa"));
Console.ReadLine();

public class Solution
{
    public string FrequencySort(string s)
    {
        var sortedString = "";
        var characterFrequency = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (characterFrequency.ContainsKey(s[i]))
                characterFrequency[s[i]]++;
            else
                characterFrequency[s[i]] = 1;
        }

        var sortedCharactersDict = characterFrequency.OrderByDescending(item => item.Value).ToDictionary();

        foreach (var sortedCharacter in sortedCharactersDict)
        {
            var frequency = sortedCharacter.Value;

            while (frequency > 0)
            {
                sortedString += sortedCharacter.Key;
                frequency--;
            }
        }

        return sortedString;
    }
}