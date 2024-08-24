Console.WriteLine(new Solution().LengthOfLastWord("   fly me   to   the moon  "));
Console.ReadLine();

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        var words = s.Trim().Split(' ');

        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (!string.IsNullOrWhiteSpace(words[i]))
                return words[i].Length;
        }

        return -1;
    }
}