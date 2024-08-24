Console.WriteLine(new Solution().IsPalindrome(1231));
Console.ReadLine();

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        //Solution with extra space
        //var digits = new List<int>();

        //while (x > 0)
        //{
        //    digits.Add(x % 10);
        //    x /= 10;
        //}

        //var leftPointer = 0;
        //var rightPointer = digits.Count - 1;

        //while (leftPointer <= rightPointer)
        //{
        //    if (digits[leftPointer] != digits[rightPointer])
        //        return false;

        //    leftPointer++;
        //    rightPointer--;
        //}

        //return true;

        //Solution without extra space
        var input = x;
        var reversedInput = 0;

        while (x > 0)
        {
            reversedInput = reversedInput * 10 + x % 10;
            x /= 10;
        }

        return input == reversedInput;
    }
}