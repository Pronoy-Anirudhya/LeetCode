Console.WriteLine(new Solution().WordPattern("aaaa", "dog cat cat dog"));
Console.ReadLine();

public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        var wordsToBeMatched = s.Split(' ');
        var charCountInPattern = pattern.Count();
        var wordCount = wordsToBeMatched.Length;

        if (charCountInPattern != wordCount)
            return false;

        var map = new Dictionary<string, string>();
        var set = new HashSet<string>();

        for (int i = 0; i < charCountInPattern; i++)
        {
            if (!map.ContainsKey(pattern[i].ToString()))
            {
                if (set.Contains(wordsToBeMatched[i]))
                    return false;

                map.Add(pattern[i].ToString(), wordsToBeMatched[i]);
                set.Add(wordsToBeMatched[i]);
            }
            else
            {
                if (map[pattern[i].ToString()] != wordsToBeMatched[i])
                    return false;
            }
        }

        return true;
    }
}