using System.Text;

Console.WriteLine(new Solution().CustomSortString("hucw", "utzoampdgkalexslxoqfkdjoczajxtuhqyxvlfatmptqdsochtdzgypsfkgqwbgqbcamdqnqztaqhqanirikahtmalzqjjxtqfnh"));
Console.ReadLine();

public class Solution
{
    public string CustomSortString(string order, string s)
    {
        StringBuilder result = new();
        int[] frequency = new int[26];

        //Count the frequency of the unsorted string.
        foreach (char ch in s)
            frequency[ch - 'a']++;

        //Now iterate through the order string which is already in sorted order. For each character in order string, get the frequency from the computed dictionary above and add that number of i-th order character into the resultant string. Also remove the entry from the dictionary since in that way, we will know that any reminaing entries in the dictionary are the characters that don't belong in the order string and add them at the end of the resultant string to get our answer.
        foreach (char ch in order)
        {
            AppendCharacter(result, ch, frequency[ch - 'a']);
            frequency[ch - 'a'] = 0;
        }

        //Add those remaining characters from the dictionary that were not part of the order string.
        for (int index = 0; index < frequency.Length; index++)
        {
            if (frequency[index] > 0)
                AppendCharacter(result, (char)(index + 'a'), frequency[index]);
        }

        return result.ToString();
    }

    private void AppendCharacter(StringBuilder result, char ch, int frequency)
    {
        for (int count = 0; count < frequency; count++)
            result.Append(ch);
    }
}