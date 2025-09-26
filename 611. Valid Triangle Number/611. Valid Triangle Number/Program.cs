Console.WriteLine(new Solution().TriangleNumber([4, 2, 3, 4]));
Console.ReadLine();

public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        int totalTriangleCount = 0;
        Array.Sort(nums);

        for (int left = 0; left < nums.Length - 2; left++)
        {
            for (int right = left + 1; right < nums.Length - 1; right++)
            {
                int sumOfTwoSides = nums[left] + nums[right];
                int lastPossibleThirdSideIndex = FindLastPossibleTriangleIndexByBinarySearch(nums, right + 1, nums.Length - 1, sumOfTwoSides); // Find the last index where nums[index] < sumOfTwoSides. This is because for a valid triangle, the sum of the lengths of any two sides must be greater than the length of the third side. So we need to find the last index where nums[index] < sumOfTwoSides. We can use binary search to find this index efficiently. The search range is from right + 1 to the end of the array because the third side must be greater than the second side (nums[right]).
                int validTriangleCount = lastPossibleThirdSideIndex - right; // Calculate the number of valid triangles that can be formed with nums[left] and nums[right] as two sides. This is simply the count of indices from right + 1 to lastPossibleThirdSideIndex. If lastPossibleThirdSideIndex is less than or equal to right, it means there are no valid third sides that can form a triangle with nums[left] and nums[right]. In this case, validTriangleCount will be 0 or negative, which is fine because we only want to add positive counts to totalTriangleCount.
                totalTriangleCount += validTriangleCount;
            }
        }

        return totalTriangleCount;
    }

    private int FindLastPossibleTriangleIndexByBinarySearch(int[] nums, int left, int right, int target)
    {
        int result = left - 1; // Initialize result to left - 1. This is because if all elements are less than target, we want to return the last index which is right (left - 1 since we sent right + 1 from above). If no elements are less than target, we want to return left - 1. So initializing result to left - 1 helps us handle both cases correctly.

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < target)
            {
                result = mid; // Update result to the current mid index. We are looking for the last index where nums[mid] < target. So we keep updating result as we find valid mid indices. Then we move to the right half to see if there's a larger valid index.
                left = mid + 1;
            }
            else
                right = mid - 1; // Move to the left half. We do not update result here because nums[mid] >= target is not valid. We are looking for the last index where nums[mid] < target. So we only update result when we find a valid mid index.
        }

        return result;
    }
}