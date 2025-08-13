Console.WriteLine(new Solution().IsPowerOfThree(29));
Console.ReadLine();

public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        if (n > 1)
        {
            while (n % 3 == 0)
                n /= 3;
        }

        // If n is 1, it means it is a power of 3 (3^0 = 1)
        return n == 1;

        // Alternative O(1) Solution: Since 3^19 is the largest power of 3 that fits in an int, we can also check if n is a divisor of 3^19. This algorithm only works for positive prime numbers.
        //return n > 0 && Math.Pow(3,19) % n==0;
    }
}