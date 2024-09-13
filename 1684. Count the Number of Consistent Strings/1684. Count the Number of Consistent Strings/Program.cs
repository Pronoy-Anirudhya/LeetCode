using System;

Console.WriteLine(new Solution().CountConsistentStrings("abe", ["ad", "bd", "aaab", "baa", "badab"]));
Console.ReadLine();

public class Solution
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        int numberOfConsistentStrings = 0;
        int[] allowedCharacterSet = new int[26];

        for (int index = 0; index < allowed.Length; index++)
            allowedCharacterSet[allowed[index] - 'a']++;

        foreach (string word in words)
        {
            bool isConsistentString = true;

            for (int index = 0; index < word.Length; index++)
            {
                if (allowedCharacterSet[word[index] - 'a'] == 0)
                {
                    isConsistentString = false;
                    break;
                }
            }

            if (isConsistentString)
                numberOfConsistentStrings++;
        }

        return numberOfConsistentStrings;
    }
}