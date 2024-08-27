using System.Collections.Immutable;

Console.WriteLine(new Solution().GroupAnagrams(["bdddddddddd", "bbbbbbbbbbc"]));
Console.ReadLine();

public class Solution
{
    //O(N * M) Solution where N is the number of words and M is the length of the word.
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var anagramDict = new Dictionary<string, List<string>>();
        var anagramGroup = new List<IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var key = HashOfTheWord(strs[i]);

            if (!anagramDict.ContainsKey(key))
                anagramDict.Add(key, [strs[i]]);
            else
                anagramDict[key].Add(strs[i]);
        }

        foreach (var groupedAanagram in anagramDict.Values)
            anagramGroup.Add(groupedAanagram);

        return anagramGroup;
    }

    public static string HashOfTheWord(string word)
    {
        var wordCountHash = new int[26];

        for (int i = 0; i < word.Length; i++ )
        {
            var index = word[i] - 'a';
            wordCountHash[index]++;
        }

        return string.Join(",", wordCountHash);
    }

    //O(NLogN) since we are using sorting
    /*public Dictionary<string, List<string>> anagramDict = new Dictionary<string, List<string>>();

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var anagramGroup = new List<IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var charArrayOfWord = strs[i].ToCharArray();
            Array.Sort(charArrayOfWord);
            AddAnagramToDict(strs, new string(charArrayOfWord), i);
        }

        foreach (var groupedAanagram in anagramDict)
            anagramGroup.Add(groupedAanagram.Value);

        return anagramGroup;
    }

    public void AddAnagramToDict(string[] strs, string key, int index)
    {
        if (!anagramDict.ContainsKey(key))
        {
            anagramDict.Add(key, [strs[index]]);
            return;
        }
        anagramDict.TryGetValue(key, out var list);
        var currentIndexesOfTheWord = anagramDict[key];
        currentIndexesOfTheWord.Add(strs[index]);
        anagramDict[key] = currentIndexesOfTheWord;
    }*/
}