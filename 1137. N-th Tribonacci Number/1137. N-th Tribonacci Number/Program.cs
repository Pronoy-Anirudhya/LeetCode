Console.WriteLine(new Solution().Tribonacci(0));
Console.ReadLine();

public class Solution
{
    public int Tribonacci(int n)
    {
        var dpTribonacci = new int[n + 1];

        if (n < 3)
            return n == 0 ? 0 : 1;

        dpTribonacci[0] = 0;
        dpTribonacci[1] = 1;
        dpTribonacci[2] = 1;

        for (int i = 3; i <= n; i++)
            dpTribonacci[i] = dpTribonacci[i - 1] + dpTribonacci[i - 2] + dpTribonacci[i - 3];

        return dpTribonacci[n];
    }
}