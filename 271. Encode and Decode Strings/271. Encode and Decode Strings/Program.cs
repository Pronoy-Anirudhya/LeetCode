var encodedString = new Solution().Encode(new string[] { "" });
Console.WriteLine("Encoded String: " + encodedString);
Console.WriteLine("Decoded Strings: " + string.Join(" - ", new Solution().Decode(encodedString)));
Console.ReadLine();

public class Solution
{
    private static readonly string separator = "*,*"; 

    public string Encode(IList<string> strs)
    {
        if (strs.Count == 0)
            return null;

        var encodedString = string.Empty;

        for (int i = 0; i < strs.Count; i++)
        {
            encodedString += strs[i];
            
            if (i < strs.Count - 1)
                encodedString += separator;
        }

        return encodedString;
    }

    public List<string> Decode(string s)
    {
        if (s == null)
            return new List<string>();

        return s.Split(separator).ToList();
    }
}