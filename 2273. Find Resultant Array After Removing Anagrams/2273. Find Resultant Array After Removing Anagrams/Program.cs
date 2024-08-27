Console.WriteLine(new Solution().RemoveAnagrams(["abba", "baba", "bbaa", "cd", "cd"]));
Console.ReadLine();

public class Solution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        var finalAnagramList = words.ToList();
        var index = 1;

        while (index < finalAnagramList.Count)
        {
            var hashOfPreviousWord = GetHashOfTheWord(finalAnagramList[index - 1]);
            var hashOfCurrentWord = GetHashOfTheWord(finalAnagramList[index]);

            if (hashOfPreviousWord == hashOfCurrentWord)
                finalAnagramList.RemoveAt(index);
            else
                index++;
        }

        return finalAnagramList;
    }

    public static string GetHashOfTheWord(string word)
    {
        var characterCountMap = new int[26];

        for (int i = 0; i < word.Length; i++)
            characterCountMap[word[i] - 'a']++;

        return string.Join(",", characterCountMap);
    }
}