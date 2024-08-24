Console.WriteLine(new Solution().GuessNumber(10));
Console.ReadLine();

public class Solution
{
    public int GuessNumber(int n)
    {
        var left = 1;
        var right = n;
        var middle = 0;

        while (left <= right)
        {
            middle = left + (right - left) / 2;
            var guessResult = guess(middle);

            if (guessResult == 0)
                return middle;
            else if (guessResult == 1)
                left = middle + 1;
            else if (guessResult == -1)
                right = middle - 1;
        }

        return middle;
    }

    public int guess(int num)
    {
        return num == 6 ? 0 : num < 6 ? 1 : -1;
    }
}