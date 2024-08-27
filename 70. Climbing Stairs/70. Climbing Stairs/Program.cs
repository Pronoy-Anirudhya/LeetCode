Console.WriteLine(new Solution().ClimbStairs(3));
Console.ReadLine();

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        var dpClimbCountAtStair = new int[n + 1];
        dpClimbCountAtStair[1] = 1;
        dpClimbCountAtStair[2] = 2;

        for (int i = 3; i <= n; i++)
            dpClimbCountAtStair[i] = dpClimbCountAtStair[i - 1] + dpClimbCountAtStair[i - 2];

        return dpClimbCountAtStair[n];
    }
}