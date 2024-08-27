Console.WriteLine(new Solution().ProductExceptSelf([1, 2, 3, 4]));
Console.ReadLine();

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var productExceptSelfResultArray = new int[nums.Length];

        //This approach uses O(n) extra memory
        /*var prefixSumDp = new int[nums.Length];
        var suffixSumDp = new int[nums.Length];

        var prefixIndex = 0;
        var suffixIndex = nums.Length - 1;

        var prefixSum = 1;
        var suffixSum = 1;

        prefixSumDp[prefixIndex] = prefixSum;
        suffixSumDp[suffixIndex] = suffixSum;
        prefixIndex++;
        suffixIndex--;

        while (prefixIndex < nums.Length)
        {
            prefixSum *= nums[prefixIndex - 1];
            prefixSumDp[prefixIndex] = prefixSum;
            suffixSum *= nums[suffixIndex + 1];
            suffixSumDp[suffixIndex] = suffixSum;

            prefixIndex++;
            suffixIndex--;
        }

        for (int i = 0; i < nums.Length; i++)
            productExceptSelfResultArray[i] = prefixSumDp[i] * suffixSumDp[i];*/

        //This approach uses O(1) constant memory
        var prefixSum = 1;
        productExceptSelfResultArray[0] = prefixSum;

        for (int i = 1; i < nums.Length; i++)
        {
            prefixSum *= nums[i - 1];
            productExceptSelfResultArray[i] = prefixSum;
        }

        var suffixSum = 1;
        productExceptSelfResultArray[nums.Length - 1] = suffixSum;

        return productExceptSelfResultArray;
    }
}