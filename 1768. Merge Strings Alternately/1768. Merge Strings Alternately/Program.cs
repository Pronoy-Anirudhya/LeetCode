Console.WriteLine(new Solution().MergeAlternately("abc", "prst"));
Console.ReadLine();

public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        var result = string.Empty;
        var iteratingLength = Math.Max(word1.Length, word2.Length);

        for (int i = 0; i < iteratingLength; i++)
        {
            if (i > word1.Length - 1)
            {
                result += word2.Substring(i);
                break;
            }
            
            if (i > word2.Length - 1)
            {
                result += word1.Substring(i);
                break;
            }

            result += word1[i].ToString() + word2[i].ToString();
        }

        return result;
    }
}