Console.WriteLine(new Solution().LengthAfterTransformations("jqktcurgdvlibczdsvnsg", 7517));
Console.ReadLine();

public class Solution
{
    private const int modulo = 1000000007;

    /*
     * Intuition: We have 26 characters from a to z. Up to 25 transformations, count for each character will be 1. On the 26th transformations, count of 'a' will become 2 (a after 25: z, after 26: ab, hence count for a after 26th transformations is 2) and so on. So from 26th transformations, we can derive the count as follows: frequencyDP[previousCountOfCharacter e.g. (round - 26)] + frequencyDP[previousCountOfTheNextCharacter e.g. (round - 26 + 1)].
    */
    public int LengthAfterTransformations(string s, int t)
    {
        int length = 0;
        int[] frequencyDP = new int[26 + t];//To simulate what will be the count of each character after t transformations, that's why t + 26 for 26 characters.

        for (int round = 0; round < 26; round++)
            frequencyDP[round] = 1;

        //From 26th onwards, we will update the count for each character with the formula derived above.
        for (int round = 26; round < t + 26; round++)
            frequencyDP[round] = (frequencyDP[round - 26] + frequencyDP[round - 26 + 1]) % modulo;

        //Lastly, we just have to add the count for each character in the frequencyDP array after t-th transformations, which is why we are adding t to get the t-th transformation count.
        foreach (char character in s)
            length = (length + frequencyDP[character - 'a' + t]) % modulo;

        return length;
    }
}