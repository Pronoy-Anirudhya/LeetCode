Console.WriteLine(new Solution().IsAnagram("anagram", "nagaram"));
Console.ReadLine();

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var wordCountMap = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!wordCountMap.ContainsKey(s[i]))
                wordCountMap.Add(s[i], 1);
            else
                wordCountMap[s[i]] = ++wordCountMap[s[i]];
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (!wordCountMap.ContainsKey(t[i]))
                return false;

            if (wordCountMap[t[i]] == 0)
                return false;

            wordCountMap[t[i]] = --wordCountMap[t[i]];
        }

        return true;
    }
}