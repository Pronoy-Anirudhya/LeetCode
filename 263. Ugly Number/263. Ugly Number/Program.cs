Console.WriteLine(new Solution().IsUgly(14));
Console.ReadLine();

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n < 1)
            return false;

        if (n == 1)
            return true;

        while (n % 2 == 0)
            n /= 2;

        while (n % 3 == 0)
            n /= 3;

        while (n % 5 == 0)
            n /= 5;

        return n == 1;
    }
}