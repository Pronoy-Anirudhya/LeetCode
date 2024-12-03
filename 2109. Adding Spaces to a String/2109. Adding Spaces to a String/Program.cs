using System.Text;

Console.WriteLine(new Solution().AddSpaces("LeetcodeHelpsMeLearn", [8, 13, 15]));
Console.ReadLine();

public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        StringBuilder result = new();
        int stringIndex = 0, spaceIndex = 0;

        while (stringIndex < s.Length || spaceIndex < spaces.Length)
        {
            if (spaceIndex < spaces.Length && stringIndex == spaces[spaceIndex])
            {
                result.Append(' ');
                spaceIndex++;
            }
            else if (stringIndex < s.Length)
            {
                result.Append(s[stringIndex]);
                stringIndex++;
            }
        }

        return result.ToString();
    }
}