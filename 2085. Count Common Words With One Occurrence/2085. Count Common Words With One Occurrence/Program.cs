Console.WriteLine(new Solution().CountWords(new string[] { "leetcode", "is", "amazing", "as", "is" }, new string[] { "amazing", "leetcode", "is" }));
Console.ReadLine();

public class Solution
{
    public int CountWords(string[] words1, string[] words2)
    {
        var count = 0;
        var wordFrequency1 = new Dictionary<string, int>();
        var wordFrequency2 = new Dictionary<string, int>();

        foreach (var word in words1)
        {
            if (wordFrequency1.ContainsKey(word))
                wordFrequency1[word]++;
            else
                wordFrequency1[word] = 1;
        }

        foreach (var word in words2)
        {
            if (wordFrequency2.ContainsKey(word))
                wordFrequency2[word]++;
            else
                wordFrequency2[word] = 1;

            if (wordFrequency1.ContainsKey(word))
                wordFrequency1[word]--;
        }

        foreach (var frequency in wordFrequency1)
        {
            if (frequency.Value == 0 && wordFrequency2.ContainsKey(frequency.Key) && wordFrequency2[frequency.Key] == 1)
                count++;
        }

        return count;
    }
}