Console.WriteLine(new Solution().MaximumEnergy([5, -10, 4, 3, 5, -9, 9, -7], 2));
Console.ReadLine();

public class Solution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        int maximumEnergy = int.MinValue;

        // Try all possible prefixes of length k. For each prefix, calculate the maximum energy we can get by taking every k-th element from the end of the array.
        for (int prefixIndex = 0; prefixIndex < k; prefixIndex++)
        {
            int currentSum = 0;

            // Calculate the sum of the prefix starting from the end of the array. This is the initial energy we get from the prefix. After each iteration, we add the next k-th element from the end of the array to the current sum. We update the maximum energy if the current sum is greater than the previous maximum. We also store the current sum back into the energy array at the current index to avoid recalculating it in future iterations. The starting element from the back will shift by one position to the left in each iteration of the outer loop (energy.Length - 1 - prefixIndex), ensuring that we consider all possible starting points for taking k-th elements from the end of the array.
            for (int index = energy.Length - 1 - prefixIndex; index >= 0; index -= k)
            {
                currentSum += energy[index];
                energy[index] = currentSum;
                maximumEnergy = Math.Max(maximumEnergy, currentSum); // Update maximum energy if current sum is greater. This ensures we always have the highest energy value found so far.
            }
        }

        return maximumEnergy;
    }
}