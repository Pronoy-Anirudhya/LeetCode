Console.WriteLine(new Solution().MinAddToMakeValid("())"));
Console.ReadLine();

public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        int openingParenthesesCount = 0, closingParenthesesCount = 0;

        // Intuition: If we encounter an opening parenthesis, we increment the count of opening parentheses. If we encounter a closing parenthesis and there is a matching opening parenthesis, we decrement the count of opening parentheses. If there is no matching opening parenthesis, we increment the count of closing parentheses. Then we return the sum of opening and closing parentheses counts, which represents the minimum number of parentheses needed to make the string valid.
        for (int index = 0; index < s.Length; index++)
        {
            if (s[index] == '(')
                openingParenthesesCount++;
            else if (s[index] == ')' && openingParenthesesCount > 0) // If we encounter a closing parenthesis and there is a matching opening parenthesis, we decrement the count of opening parentheses.
                openingParenthesesCount--;
            else
                closingParenthesesCount++; // If there is no matching opening parenthesis, we increment the count of closing parentheses.
        }

        return openingParenthesesCount + closingParenthesesCount; // Return the total number of parentheses needed to make the string valid which is the sum of opening and closing parentheses counts.
    }
}