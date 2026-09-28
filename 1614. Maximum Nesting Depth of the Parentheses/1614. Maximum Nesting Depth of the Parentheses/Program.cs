Console.WriteLine(new Solution().MaxDepth("()()(())()"));
Console.ReadLine();

public class Solution
{
    public int MaxDepth(string s)
    {
        int maxDepth = 0, depth = 0; // maxDepth stores the maximum depth encountered, depth stores the current depth

        // Iterate through each character in the string and update the depth accordingly
        for (int index = 0; index < s.Length; index++)
        {
            // If the current character is '(', increment the depth and update maxDepth if necessary
            if (s[index] == '(')
            {
                depth++;
                maxDepth = Math.Max(maxDepth, depth); // Update maxDepth if the current depth exceeds it
            }
            else if (s[index] == ')')
                depth--; // Decrement the depth when encountering a closing parenthesis
        }

        return maxDepth;
    }
}