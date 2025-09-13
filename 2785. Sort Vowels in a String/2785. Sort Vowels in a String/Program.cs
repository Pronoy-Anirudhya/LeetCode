using System.Text;

Console.WriteLine(new Solution().SortVowels("lEetcOde"));
Console.ReadLine();

public class Solution
{
    public string SortVowels(string s)
    {
        StringBuilder result = new StringBuilder();
        HashSet<char> vowels = ['A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'];
        int[] vowelCount = new int['u' + 1];
        int currentVowelIndex = 0;

        // We count the number of each vowel in the string and then use count sort.
        foreach (char character in s)
        {
            if (vowels.Contains(character))
                vowelCount[character]++;
        }

        for (int index = 0; index < s.Length; index++)
        {
            // If the character is not a vowel, append it to the result as is.
            if (!vowels.Contains(s[index]))
            {
                result.Append(s[index]);
                continue;
            }

            // Find the next vowel in the count array and append it to the result.
            while (vowelCount[currentVowelIndex] == 0)
                currentVowelIndex++;

            // Append the vowel and decrement its count. We are guaranteed that the vowel count is > 0 here. currentVowelIndex will always be a vowel here.
            result.Append((char)currentVowelIndex);
            vowelCount[currentVowelIndex]--;
        }

        return result.ToString();
    }
}