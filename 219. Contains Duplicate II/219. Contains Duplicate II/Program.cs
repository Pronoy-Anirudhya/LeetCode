var nums = new int[] { 1, 0, 1, 1 };
Console.WriteLine(new Solution().ContainsNearbyDuplicate(nums, 1));
Console.ReadLine();

public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var numIndexMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (numIndexMap.ContainsKey(nums[i]))
            {
                var previousIndex = numIndexMap[nums[i]];

                if (i - previousIndex <= k)
                    return true;

                numIndexMap[nums[i]] = i;
            }
            else
                numIndexMap.Add(nums[i], i);
        }

        return false;
    }
}