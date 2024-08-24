Console.WriteLine(new Solution().ThreeSum([-1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4]));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var threeSumTriplets = new List<IList<int>>();
        Array.Sort(nums);

        if (nums[0] > 0)
            return threeSumTriplets;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var firstNumber = nums[i];

            if (i > 0 && nums[i - 1] == firstNumber)
                continue;

            int left = i + 1, right = nums.Length - 1;

            while (left < right)
            {
                var threeSum = firstNumber + nums[left] + nums[right];

                if (threeSum > 0)
                    right--;
                else if (threeSum < 0)
                    left++;
                else if (threeSum == 0)
                {
                    threeSumTriplets.Add([firstNumber, nums[left], nums[right]]);

                    left += 1;

                    while(left < right && nums[left] == nums[left - 1])
                        left++;

                    right -= 1;

                    while (right > left && nums[right + 1] == nums[right])
                        right--;
                }
            }
        }

        return threeSumTriplets;
    }
}