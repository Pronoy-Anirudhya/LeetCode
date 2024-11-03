using System.Collections.Generic;

Console.WriteLine(new Solution().Subsets([1, 2, 3]));
Console.ReadLine();

public class Solution
{
    private List<IList<int>> subSets = [];

    public IList<IList<int>> Subsets(int[] nums)
    {
        DFSBacktracking([], nums, 0);
        return subSets;
    }

    private void DFSBacktracking(List<int> set, int[] nums, int index)
    {
        if (index >= nums.Length)
        {
            int[] tempSet = new int[set.Count];
            set.CopyTo(tempSet);
            subSets.Add(tempSet);
            return;
        }

        //We have two choices to create a Subset of nums. Either add the next number (index + 1) to the set or add empty/null value for each step. So first we will add the next number recursively until we reach the end when we meet the base case and add the set to the result. And then we will add the empty/null value to the set in the same way.
        set.Add(nums[index]);
        DFSBacktracking(set, nums, index + 1);

        set.Remove(nums[index]);//Lets say we [1]. Now we went down and added 2 in the list and eventually it returned through the base case. Now the set is [1, 2]. In the next line, we want to choose the second option of adding empty value to [1]. Thats why we are removing the last element which is a t index after the base case.
        DFSBacktracking(set, nums, index + 1);
    }
}