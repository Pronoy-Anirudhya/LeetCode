Console.WriteLine(new Solution().ClimbStairs(3));
Console.ReadLine();

public class Solution
{
    public int ClimbStairs(int n)
    {
        //if (n <= 2)
        //    return n;

        //var dpClimbCountAtStair = new int[n + 1];
        //dpClimbCountAtStair[1] = 1;
        //dpClimbCountAtStair[2] = 2;

        //for (int i = 3; i <= n; i++)
        //    dpClimbCountAtStair[i] = dpClimbCountAtStair[i - 1] + dpClimbCountAtStair[i - 2];

        //return dpClimbCountAtStair[n];

        if (n <= 2)
            return n;

        //DP - Bottom up approach
        var dpMemoization = new int[n + 1]; //Since we are starting from 0 step to rweach towards n, so there are actually n+1 steps to cover ion terms of 0-indexed array e.g. for n = 3, steps are 0, 1, 2, 3 (n + 1)
        dpMemoization[n] = dpMemoization[n - 1] = 1; //Since bottom-up, so we are setting the base case which is the last two steps. No matter what's the value of n is, from the last two steps it's always going to be 1 way of reaching the n.

        //Now just loop through the third last step to zero and add the respective two steps that are ahead of the current index
        for (int index = n - 2; index >= 0; index--)
            dpMemoization[index] = dpMemoization[index + 1] + dpMemoization[index + 2];

        return dpMemoization[0];
    }
}