Console.WriteLine(new Solution().TimeRequiredToBuy(new int[] { 84, 49, 5, 24, 70, 77, 87, 8 }, 3));
Console.ReadLine();

public class Solution
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var ticketToBuy = tickets[k];
        var time = 0;

        for (int i = 0; i < tickets.Length; i++)
        {
            if (tickets[i] >= ticketToBuy)
                time += i > k ? ticketToBuy - 1 : ticketToBuy;
            else
                time += tickets[i];
        }

        return time;
    }
}