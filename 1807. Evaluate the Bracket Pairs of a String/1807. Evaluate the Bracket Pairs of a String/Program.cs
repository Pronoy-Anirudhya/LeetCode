Console.WriteLine(new Solution().Evaluate("(a)", [["a", "b"]]));
Console.ReadLine();

public class Solution
{
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        string result = string.Empty;
        Dictionary<string, string> map = [];

        // Build the map from knowledge. First element of each inner list is the key, second is the value. Key will be unique, it will not be repeated in the knowledge list.
        for (int index = 0; index < knowledge.Count; index++)
        {
            var key = knowledge[index][0];
            var value = knowledge[index][1];
            map[key] = value;
        }

        // Iterate through the string s, if we encounter a '(', we will extract the key and look it up in the map. If the key is found, we will append the value to the result, otherwise we will append a '?' to the result. If we encounter any other character, we will append it to the result.
        for (int index = 0; index < s.Length; index++)
        {
            // If the current character is not '(', we will append it to the result and continue to the next character.
            if (s[index] != '(')
            {
                result += s[index];
                continue;
            }

            // If the current character is '(', we will extract the key and look it up in the map. We will increment the index to skip the '(' character.
            var key = String.Empty;

            while (s[++index] != ')' && index < s.Length)
                key += s[index];

            // If the key is found in the map, we will append the value to the result, otherwise we will append a '?' to the result.
            if (map.TryGetValue(key, out var value))
                result += value;
            else
                result += '?';
        }

        return result;
    }
}