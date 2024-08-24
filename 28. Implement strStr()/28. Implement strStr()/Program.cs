Console.WriteLine(new Solution().StrStr("aabaaabaaac", "aabaaac"));//mississippi, issip
Console.ReadLine();

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        if (needle.Length == 0)
            return 0;

        if (haystack.Length < needle.Length)
            return -1;
        
        var resultIndex = -1;

        for (int haystackIndex = 0; haystackIndex <= haystack.Length - needle.Length; )
        {
            if (haystack[haystackIndex] != needle[0])
            {
                haystackIndex++;
                continue;
            }

            resultIndex = haystackIndex;

            if (needle.Length == 1)
                return resultIndex;

            var tempFirstNeedleCharacterIndex = -1;

            for (int needleIndex = 1; needleIndex < needle.Length; needleIndex++)
            {
                haystackIndex++;

                if (haystackIndex >= haystack.Length)
                    return -1;

                if (needle[needleIndex] != haystack[haystackIndex])
                {
                    resultIndex = -1;
                    break;
                }

                if (needleIndex == needle.Length - 1)
                    return resultIndex;

                if (tempFirstNeedleCharacterIndex == -1 && haystack[haystackIndex] == needle[0])
                    tempFirstNeedleCharacterIndex = haystackIndex;
            }

            if (tempFirstNeedleCharacterIndex != -1)
                haystackIndex = tempFirstNeedleCharacterIndex;
        }

        return resultIndex;
    }
}