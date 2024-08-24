Console.WriteLine(new Solution().CountPrimes(10));
Console.ReadLine();

public class Solution
{
    public int CountPrimes(int n)
    {
        if (n <= 2)
            return 0;

        Dictionary<int, int> numbers = new Dictionary<int, int>();
        int primeCount = 0;

        for (int i = 2; i < n; i++)
            numbers.Add(i, 0);

        for (int i = 2; i < n; i++)
        {
            if (numbers[i] == 0)
            {
                primeCount++;

                for (int j = i + i; j < n; j += i)
                {
                    if (numbers[j] != 1)
                        numbers[j] = 1;
                }
            }
        }

        return primeCount;
    }
}