Console.WriteLine(new Solution().MaxProfit([7, 2, 5, 1, 1, 1, 1]));
Console.ReadLine();

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int maxProfit = 0;

        if (prices.Length == 1)
            return maxProfit;

        int left = 0, right = 1;

        while (right < prices.Length)
        {
            if (prices[left] > prices[right])
                left = right;
            else
            {
                int currentProfit = prices[right] - prices[left];
                maxProfit = Math.Max(maxProfit, currentProfit);
            }

            right++;
        }

        return maxProfit;
    }
}