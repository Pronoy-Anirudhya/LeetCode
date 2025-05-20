Console.WriteLine(new Solution().IsZeroArray([4, 3, 2, 1], [[1, 3], [0, 2]]));
Console.ReadLine();

public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int[] differenceArray = new int[nums.Length + 1];
        int[] prefixSumOfDA = new int[nums.Length + 1];
        int prefixSum = 0;

        //Intuition: We will use the "Difference Array" technique to mark the ranges in the difference array. For this, we need an array of size n+1. n1 is used to handle the right boundary of the range when right boundary of range is equal to n. Here, we will increment the left boundary by 1 and decrement the right boundary by 1. The prefix sum of the difference array will give us the number of times each index is affected by the queries.
        for (int index = 0; index < queries.Length; index++)
        {
            int left = queries[index][0], right = queries[index][1];
            differenceArray[left]++;
            differenceArray[right + 1]--;
        }

        //Intuition: We will calculate the prefix sum of the difference array. The prefix sum of the difference array will give us the number of times each index is affected by the queries.
        for (int index = 0; index < differenceArray.Length; index++)
        {
            prefixSum += differenceArray[index];
            prefixSumOfDA[index] = prefixSum;
        }

        //Intuition: We will check if the prefix sum of the difference array is greater than the original array. If it is, then we will return false. Otherwise, we will return true.
        for (int index = 0; index < nums.Length; index++)
        {
            if (nums[index] > prefixSumOfDA[index])
                return false;
        }

        return true;
    }
}