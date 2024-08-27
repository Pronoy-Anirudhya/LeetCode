Console.WriteLine(new Solution().IsHappy(2));
Console.ReadLine();

public class Solution
{
    public bool IsHappy(int n)
    {
        var sumMap = new HashSet<int>();
        var sum = 0;

        while (sum != 1)
        {
            sum = 0;

            while (n > 0)
            {
                var r = n % 10;
                sum += (r * r);
                n /= 10;
            }

            if (sumMap.Contains(sum))
                return false;

            sumMap.Add(sum);
            n = sum;
        }

        return true;
    }
}