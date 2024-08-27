Console.WriteLine(new Solution().IsIsomorphic("badc", "baba"));
Console.ReadLine();

public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var map = new Dictionary<string, int>();
        var set = new HashSet<string>();

        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i].ToString()))
            {
                if (map[s[i].ToString()] != t[i])
                    return false;
            }
            else
            {
                if (set.Contains(t[i].ToString()))
                    return false;

                map[s[i].ToString()] = t[i];
                set.Add(t[i].ToString());
            }
        }

        return true;
    }
}