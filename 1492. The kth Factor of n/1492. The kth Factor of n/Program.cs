Console.WriteLine(new Solution().KthFactor(4, 4));
Console.ReadLine();

public class Solution
{
    public int KthFactor(int n, int k)
    {
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                k--;

                if (k == 0)
                    return i;
            }
        }

        return -1;
    }
}