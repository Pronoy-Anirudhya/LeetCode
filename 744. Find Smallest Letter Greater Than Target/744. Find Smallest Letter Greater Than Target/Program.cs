var leeters = new char[] { 'c', 'f', 'j' };
Console.WriteLine(new Solution().NextGreatestLetter(leeters, 'f'));
Console.ReadLine();

public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        if (target >= letters[letters.Length - 1])
            return letters[0];

        target++;
        var left = 0;
        var right = letters.Length - 1;

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (letters[middle] == target)
                return target;

            if (letters[middle] < target)
                left = middle + 1;
            else
                right = middle;
        }

        return letters[right];
    }
}