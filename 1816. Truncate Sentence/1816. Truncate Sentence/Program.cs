Console.WriteLine(new Solution().TruncateSentence("Hello how are you Contestant", 4));
Console.ReadLine();

public class Solution
{
    public string TruncateSentence(string s, int k)
    {
        var result = string.Empty;

        for (int i = 0; i < s.Length; i++)
        {
            var character = s[i];

            if (character == ' ')
            {
                k -= 1;

                if (k > 0)
                    result += character;
                else
                    break;
            }
            else
            {
                result += character;
            }
        }

        return result;
    }
}