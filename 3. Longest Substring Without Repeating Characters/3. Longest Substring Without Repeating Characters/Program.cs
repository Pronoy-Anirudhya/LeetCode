Console.WriteLine(new Solution().LengthOfLongestSubstring("tmmzuxt"));//vqblqcb = 4 //tmmzuxt = 5 //blqsearxxxbiwqa = 8 aabaab!bb = 3
Console.ReadLine();

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0 || s.Length == 1)
            return s.Length;

        var characterMap = new Dictionary<char, int>();
        var result = 0;
        var repeatedSubstringLength = 0;
        var leftPointer = 0;
        var rightPointer = 0;

        while (leftPointer < s.Length && rightPointer < s.Length)
        {
            if (s.Length == 0 || s.Length == 1)
                return s.Length;

            if (characterMap.ContainsKey(s[rightPointer]))
            {
                if (characterMap[s[rightPointer]] >= leftPointer)
                {
                    leftPointer = ++characterMap[s[rightPointer]];
                    result = Math.Max(result, repeatedSubstringLength);
                    repeatedSubstringLength = rightPointer - leftPointer;
                }
                
                characterMap[s[rightPointer]] = rightPointer;
            }
            else
            {
                characterMap.Add(s[rightPointer], rightPointer);
            }

            rightPointer++;
            repeatedSubstringLength++;
        }

        return Math.Max(result, repeatedSubstringLength);
    }
}