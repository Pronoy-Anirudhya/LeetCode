Console.WriteLine(new Solution().ClosestPrimes(69346, 69379));
Console.ReadLine();

public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        int[] result = [-1, -1];
        bool[] isPrime = SieveOfEratosthenes(right);
        int previousPrimeIndex = -1, minimumDistance = int.MaxValue;

        for (int index = left; index <= right; index++)
        {
            //No need to go further if it's not a prime number.
            if (!isPrime[index])
                continue;

            //First prime number in the range. So update the previousPrimeIndex value with current index and move on to find the next prime number so that we can calculate the distance between them.
            if (previousPrimeIndex == -1)
            {
                previousPrimeIndex = index;
                continue;
            }

            int currentDistance = index - previousPrimeIndex;

            //We will update the result array and minimumDistance values if and only if the currentDistance values is smaller than the current minimumDistance
            if (currentDistance < minimumDistance)
            {
                result = [previousPrimeIndex, index];
                minimumDistance = currentDistance;
            }

            //It's a bit of optimization. The smalles distance between two Prime numbers is 2. So if we found the first pair of Prime numbers starting from LEFT with a distance 2, we can just return the pair as result since we were asked to return the pair with the smallest distance and if there are multiple pairs with same distance, then return the pair with the smalles LEFT value.
            if (minimumDistance <= 2)
                return result;

            previousPrimeIndex = index;
        }

        return result;
    }

    /*
     * Sieve of Eratosthenes algorithm is an efficient way to determine all the Prime numbers up to N. Time Complexity: O(Nlog(logN)). The core idea is as follows:
     * 1. Prepare a list of numbers from 2 up to N. Mark all of the numbers as PRIME and then start iterating and marking the Non-PRIME numbers.
     * 2. Only enter the iteration if and only if the current number is marked as PRIME. If yes, then start iterating from (currentIndex + 1) to N. When iterating, if the current number is divisible by the cuyrrent prime number or greater or equal to the square of the current prime number, marke them as Non-PRIME.
     * 3. After you finish, the numbers marked as PRIMEs are your answer.
    */
    private bool[] SieveOfEratosthenes(int right)
    {
        bool[] isPrime = new bool[right + 1];
        
        for (int index = 0; index <= right; index++)
            isPrime[index] = true;

        isPrime[1] = false;//Since 1 is not considered as PRIME, we marking it as Non-PRIME

        for (int index = 2; index * index <= right; index++)
        {
            if (isPrime[index])
            {
                for (int nonPrimeIndex = index * index; nonPrimeIndex <= right; nonPrimeIndex += index)
                    isPrime[nonPrimeIndex] = false;
            }
        }

        return isPrime;
    }
}