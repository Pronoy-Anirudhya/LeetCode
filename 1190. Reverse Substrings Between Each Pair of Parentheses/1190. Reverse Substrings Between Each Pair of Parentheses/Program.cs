using System.Text;

Console.WriteLine(new Solution().ReverseParentheses("(ed(et(oc))el)"));
Console.ReadLine();

public class Solution
{
    // Wormhole traversal technique. Time complexity: O(n), Space complexity: O(n). The idea is to traverse the string and when we encounter a parenthesis, we jump to its corresponding pair and reverse the direction of traversal. We can use a stack to keep track of the indices of the opening parentheses. When we encounter a closing parenthesis, we pop the index of the last opening parenthesis from the stack and create a mapping between the two indices. We need both mappings: one from the opening parenthesis to the closing parenthesis and one from the closing parenthesis to the opening parenthesis. This will allow us to jump between the two indices during traversal.
    public string ReverseParentheses(string s)
    {
        var result = new StringBuilder();
        Stack<int> parenthesis = []; // Stack to keep track of the indices of the opening parentheses
        Dictionary<int, int> mapOfParenthesisIndex = []; // Dictionary to map the index of each parenthesis to its corresponding pair both ways (opening to closing and closing to opening)

        // First, we need to map the index of each parenthesis to its corresponding pair. We can do this by using a stack to keep track of the indices of the opening parentheses. When we encounter a closing parenthesis, we pop the index of the last opening parenthesis from the stack and create a mapping between the two indices. We need both mappings: one from the opening parenthesis to the closing parenthesis and one from the closing parenthesis to the opening parenthesis. This will allow us to jump between the two indices during traversal.
        for (int index = 0; index < s.Length; index++)
        {
            if (s[index] == '(')
                parenthesis.Push(index);
            else if (s[index] == ')')
            {
                int startIndex = parenthesis.Pop();
                int endIndex = index;
                mapOfParenthesisIndex[startIndex] = endIndex; // Map the index of the opening parenthesis to its corresponding closing parenthesis
                mapOfParenthesisIndex[endIndex] = startIndex; // Map the index of the closing parenthesis to its corresponding opening parenthesis
            }
        }

        // Wormhole traversal technique: The idea is to traverse the string and when we encounter a parenthesis, we jump to its corresponding pair and reverse the direction of traversal.
        int pointer = 0, dx = 1;
        while (pointer < s.Length)
        {
            if (s[pointer] == '(' || s[pointer] == ')')
            {
                dx *= -1; // Reverse the direction of traversal
                pointer = mapOfParenthesisIndex[pointer]; // Jump to the corresponding parenthesis
            }
            else
                result.Append(s[pointer]); // Append the character to the result string since it is not a parenthesis. Direction of traversal is already handled by the dx variable, so we can just append the character to the result string.

            pointer += dx; // Move the pointer to the next character in the new direction. It will be either the next character after the closing parenthesis or the previous character before the opening parenthesis.
        }

        return result.ToString();
    }

    // The O(n2) solution with O(n) space complexity. The idea is to use a stack to keep track of the indices of the opening parentheses. When we encounter a closing parenthesis, we pop the index of the last opening parenthesis from the stack and reverse the substring between the two indices. We can use a StringBuilder to build the result string since it is more efficient than using a string for concatenation.
    /*public string ReverseParentheses(string s)
    {
        var result = new StringBuilder();
        Stack<int> parenthesis = [];
        
        for (int index = 0; index < s.Length; index++)
        {
            if (s[index] == '(')
                parenthesis.Push(result.Length); // Push the index of the opening parenthesis to the stack. We use result.Length instead of index because we want to reverse the substring in the result string, not in the original string. The result string will be built as we traverse the original string, so the indices of the characters in the result string will be different from the indices of the characters in the original string.
            else if (s[index] == ')')
            {
                int startIndex = parenthesis.Pop();
                ReverseSubstring(result, startIndex, result.Length - 1); // Reverse the substring between the two indices in the result string. We use result.Length - 1 instead of index - 1 because we want to reverse the substring in the result string, not in the original string. The result string will be built as we traverse the original string, so the indices of the characters in the result string will be different from the indices of the characters in the original string.
            }

            else
                result.Append(s[index]); // Append the character to the result string since it is not a parenthesis. We can use StringBuilder's Append method to efficiently append the character to the result string.
        }

        return result.ToString();
    }

    private void ReverseSubstring(StringBuilder result, int startIndex, int endIndex)
    {
        while (startIndex < endIndex)
            (result[startIndex], result[endIndex]) = (result[endIndex--], result[startIndex++]); // Swap the characters at the start and end indices and move the indices towards the center of the substring until they meet or cross each other. This will reverse the substring in place without using any additional space.
    }*/
}