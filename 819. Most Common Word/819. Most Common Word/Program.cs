var paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
var banned = new string[] { "hit" };
Console.WriteLine(new Solution().MostCommonWord(paragraph, banned));
Console.ReadLine();

public class Solution
{
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var mostCommonWord = string.Empty;
        var wordCount = new Dictionary<string, int>();
        var index = 0;
        var maxWordCount = int.MinValue;
        var word = string.Empty;

        paragraph = paragraph.Trim().ToLower();

        while (index < paragraph.Length)
        {
            var asciiValue = (int)paragraph[index];

            if (asciiValue < 97 || asciiValue > 122)
            {
                if (word != string.Empty && !banned.Contains(word))
                {
                    var count = 1;

                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                        count = wordCount[word];
                    }
                    else
                        wordCount[word] = count;

                    if (count > maxWordCount)
                    {
                        mostCommonWord = word;
                        maxWordCount = count;
                    }
                }

                word = string.Empty;
                index++;
                continue;
            }

            word += paragraph[index];
            index++;
        }

        return mostCommonWord != string.Empty ? mostCommonWord : word;
    }
}