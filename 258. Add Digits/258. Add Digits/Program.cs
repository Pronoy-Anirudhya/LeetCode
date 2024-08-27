Console.WriteLine(new Solution().AddDigits(38));
Console.ReadLine();

public class Solution
{
    public int AddDigits(int num)
    {
        //Digital root solution O(1)
        /*
        1=1; 2=2; 3=3; 4=4; 5=5; 6=6; 7=7; 8=8; 9=9;
        10=1; 11=2; 12=3; 13=4; 14=5; 15=6; 16=7; 17=8; 18=9;
        19=1; 20=2; 21=3; 22=4; 23=5; 24=6; 25=7; 26=8; 27=9; 
        */
        /*if (num < 10)
            return num;

        return num % 9 == 0 ? 9 : num % 9;*/

        if (num < 10)
            return num;

        while (num > 0)
        {
            var sum = 0;

            while (num > 9)
            {
                var remainder = num % 10;
                sum += remainder;
                num /= 10;
            }

            if (sum < 10)
                return sum;
        }

        return 0;
    }
}