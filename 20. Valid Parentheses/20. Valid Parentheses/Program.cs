Console.WriteLine(new Solution().IsValid("{"));
Console.ReadLine();

public class Solution
{
    public bool IsValid(string s)
    {
        var parenthesesStack = new Stack<string>();
        var parenthesesPair = new Dictionary<string, string>
        {
            { ")", "(" },
            { "}", "{" },
            { "]", "[" }
        };

        for (int i = 0; i < s.Length; i++)
        {
            var parentheses = s[i].ToString();

            if (parenthesesPair.ContainsValue(parentheses))
                parenthesesStack.Push(parentheses);
            else if (parenthesesStack.Count == 0 || parenthesesStack.Pop() != parenthesesPair[parentheses])
                return false;
        }

        return parenthesesStack.Count == 0;
    }
}