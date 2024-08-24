var nums = new int[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }; //5, 2, 1, 2, 5, 2, 1, 2, 5 = 8 //4,2,4,5,6 = 17 //1,2,9,3,2,5,1,5,9,6,1 = 21
//187,470,25,436,538,809,441,167,477,110,275,133,666,345,411,459,490,266,987,965,429,166,809,340,467,318,125,165,809,610,31,585,970,306,42,189,169,743,78,810,70,382,367,490,787,670,476,278,775,673,299,19,893,817,971,458,409,886,434 = 16911
Console.WriteLine(new Solution().MaximumUniqueSubarray(nums));
Console.ReadLine();

public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        var result = 0;
        var sum = 0;
        var currentWindowSum = 0;
        var leftPointer = 0;
        var rightPointer = 0;
        var numberMap = new Dictionary<int, int>();
        var sumMap = new Dictionary<int, int>();

        while (leftPointer < nums.Length && rightPointer < nums.Length)
        {
            sum += nums[rightPointer];

            if (numberMap.ContainsKey(nums[rightPointer]))
            {
                if (numberMap[nums[rightPointer]] >= leftPointer)
                {
                    leftPointer = ++numberMap[nums[rightPointer]];
                    result = Math.Max(result, currentWindowSum);
                    currentWindowSum = sum - sumMap[nums[rightPointer]];
                }
                else
                {
                    currentWindowSum += nums[rightPointer];
                }

                numberMap[nums[rightPointer]] = rightPointer;
                sumMap[nums[rightPointer]] = sum;
            }
            else
            {
                numberMap.Add(nums[rightPointer], rightPointer);
                sumMap.Add(nums[rightPointer], sum);
                currentWindowSum += nums[rightPointer];
            }

            rightPointer++;
        }

        return Math.Max(result, currentWindowSum);
    }
}