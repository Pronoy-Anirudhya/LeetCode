Console.WriteLine(new Solution().MaxWidthRamp([9, 8, 1, 0, 1, 9, 4, 0, 4, 1]));
Console.ReadLine();

public class Solution
{
    public int MaxWidthRamp(int[] nums)
    {
        //O(n) solution
        int maximumRampWidth = 0, currentRampWidth = 0, currentMaximumRightNumber = int.MinValue, left = 0;
        int[] maximumNumberInTheRight = new int[nums.Length]; //Value of each index will indicate the maximum number on the right from that particula index

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            currentMaximumRightNumber = Math.Max(currentMaximumRightNumber, nums[i]);
            maximumNumberInTheRight[i] = currentMaximumRightNumber;
        }

        for (int right = 1; right < nums.Length; right++)
        {
            int maxRightNumber = maximumNumberInTheRight[right];

            //Increment LEFT as long as it's bigger than the current right index's maximum number on the right. Then calculate the maximum ramp width 
            while (nums[left] > maxRightNumber && left < right)
                left++;

            currentRampWidth = right - left;
            maximumRampWidth = Math.Max(maximumRampWidth, currentRampWidth);
        }

        //Brute-force O(n2) Solution
        /*for (int left = 0; left < nums.Length-1; left++)
        {
            int leftNumber = nums[left];

            //Since we want to get the maximum width, so for every number, we will start from the very last number and try to satisfy the condition that left number is <= right number. If true, that's the MAXIMUM WIDTH for that particular number, so no point going further left to it since that won't never be bigger than the current max. So we break from that loop and start processing the next number.
            for (int right = nums.Length - 1; right > left; right--)
            {
                int rightNumber = nums[right];

                if (leftNumber <= rightNumber)
                {
                    currentRampWidth = right - left;
                    maxRampWidth = Math.Max(maxRampWidth, currentRampWidth);
                    break;
                }
            }
        }*/

        return Math.Max(maximumRampWidth, currentRampWidth);
    }
}