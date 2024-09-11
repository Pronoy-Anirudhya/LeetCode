Console.WriteLine(new Solution().MinRemoveToMakeValid("lee(t(c)o)de)"));
Console.ReadLine();

public class Solution
{
    public string MinRemoveToMakeValid(string s)
    {
        var characters = s.ToCharArray();
        Stack<int> invalidStartParenthesesIndex = [];

        for (int index = 0; index < characters.Length; index++)
        {
            if (characters[index] == '(')
                invalidStartParenthesesIndex.Push(index);
            else if (characters[index] == ')')
            {
                if (invalidStartParenthesesIndex.Count == 0)
                    characters[index] = ' ';
                else
                    invalidStartParenthesesIndex.Pop();
            }
        }

        while (invalidStartParenthesesIndex.Count > 0)
            characters[invalidStartParenthesesIndex.Pop()] = ' ';

        return new string(characters).Replace(" ", "");
    }
}