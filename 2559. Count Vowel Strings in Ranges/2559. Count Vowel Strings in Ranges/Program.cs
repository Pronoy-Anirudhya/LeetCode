Console.WriteLine(new Solution().VowelStrings(["aba", "bcb", "ece", "aa", "e"], [[0, 2], [1, 4], [1, 1]]));
Console.ReadLine();

public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        int[] result = new int[queries.Length];
        int[] prefixSumOfVowelCount = new int[words.Length];
        int vowelCountTillNow = 0;

        //Precomputing the prefix sum of the vowel count so that we can just use the query range to calculate the vowel count within that window by just subtraction.
        for (int index = 0; index < words.Length; index++)
        {
            string word = words[index];
            (string firstCharacter, string lastCharacter) = (word[0].ToString(), word[word.Length - 1].ToString());

            if (IsVowel(firstCharacter) && IsVowel(lastCharacter))
                prefixSumOfVowelCount[index] = ++vowelCountTillNow;
            else
                prefixSumOfVowelCount[index] = vowelCountTillNow;
        }

        for (int index = 0; index < queries.Length; index++)
        {
            int vowelCountOutsideTheQueryWindow = queries[index][0] - 1 < 0 ? 0 : prefixSumOfVowelCount[queries[index][0] - 1];
            int vowelCountForThisQuery = prefixSumOfVowelCount[queries[index][1]] - vowelCountOutsideTheQueryWindow; //Count of this range will be end range count found in the prefixsum array minus the outside range's count e.g. [1, 1, 2, 3, 4] is the prefix sum of vowel count. So [1,4] queries answer would be prefixSum[4] - prefixSum[0].
            result[index] = vowelCountForThisQuery;
        }

        return result;
    }

    private static bool IsVowel(string character)
    {
        return character == "a" || character == "e" || character == "i" || character == "o" || character == "u";
    }
}