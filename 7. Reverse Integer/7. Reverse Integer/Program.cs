var number = 2147483647;//-123;
Console.WriteLine(new Solution().Reverse(number));
Console.ReadLine();

public class Solution
{
    public int Reverse(int x)
    {
        int reversedNumber = 0;

        while (x != 0)
        {
            var remainder = x % 10;
            x /= 10;

            try
            {
                reversedNumber = checked((reversedNumber * 10) + remainder);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        return reversedNumber;
    }
}