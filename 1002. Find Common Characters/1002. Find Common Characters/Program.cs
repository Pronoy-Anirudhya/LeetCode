Console.WriteLine(new Solution().CommonChars(["acabcddd", "bcbdbcbd", "baddbadb", "cbdddcac", "aacbcccd", "ccccddda", "cababaab", "addcaccd"]));
//Console.WriteLine(new Solution().CommonChars(["bella", "label", "roller"]));
Console.ReadLine();

public class Solution
{
    public IList<string> CommonChars(string[] words)
    {
        var commonCharacters = new List<string>();
        var characterFrequencies = new List<int[]>();

        foreach (var word in words)
        {
            var characterFrequency = new int[26];

            for (int i = 0; i < word.Length; i++)
                characterFrequency[word[i] - 'a']++;

            characterFrequencies.Add(characterFrequency);
        }

        for (int charIndex = 0; charIndex < 26; charIndex++)
        {
            int minOccurrence = int.MaxValue;
            var doesOccurInAllWords = true;

            for (int wordIndex = 0; wordIndex < characterFrequencies.Count; wordIndex++)
            {
                if (characterFrequencies[wordIndex][charIndex] == 0)
                {
                    doesOccurInAllWords = false;
                    break;
                }

                minOccurrence = Math.Min(minOccurrence, characterFrequencies[wordIndex][charIndex]);
            }

            if (doesOccurInAllWords)
                while (minOccurrence-- > 0)
                    commonCharacters.Add(((char)(charIndex + 'a')).ToString());
        }

        return commonCharacters;
    }
}