var accounts = new int[2][];// { { 1, 2, 3 }, { 3, 2, 1 } };
accounts[0] = new int[] { 1, 2, 3 };
accounts[1] = new int[] { 3, 2, 1 };

Console.WriteLine(new Solution().MaximumWealth(accounts));
Console.ReadLine();

public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        var maximumWealth = 0;

        for (int i = 0; i < accounts.Length; i++)
        {
            var customerWealth = 0;
            var customerBankAccounts = accounts[i];

            for (int j = 0; j < customerBankAccounts.Length; j++)
                customerWealth += customerBankAccounts[j];

            maximumWealth = Math.Max(customerWealth, maximumWealth);
        }

        return maximumWealth;
    }
}