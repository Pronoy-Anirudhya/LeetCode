Console.WriteLine(new Solution().TriangularSum([1, 2, 3, 4, 5]));
Console.ReadLine();

public class Solution
{
    public int TriangularSum(int[] nums)
    {
        int length = nums.Length; // Use a separate variable to track the current length. This avoids using a dynamic list and keeps the code efficient.

        while (length > 0)
        {
            for (int index = 0; index < length - 1; index++)
                nums[index] = (nums[index] + nums[index + 1]) % 10; // Update the current element with the sum of itself and the next element, modulo 10. This is done in-place to save space. No need for a temporary list.

            length--; // Decrease the length for the next iteration. This effectively "removes" the last element from consideration.
        }

        return nums[0];
    }
}