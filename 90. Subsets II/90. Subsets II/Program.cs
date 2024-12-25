Console.WriteLine(new Solution().SubsetsWithDup([1, 2, 2]));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        IList<IList<int>> subsets = [];
        Array.Sort(nums);
        Backtracking(subsets, [], nums, 0);
        return subsets;
    }

    private void Backtracking(IList<IList<int>> subsets, List<int> subsetsFromPreviousStep, int[] nums, int index)
    {
        if (index >= nums.Length)
        {
            subsets.Add(new List<int>(subsetsFromPreviousStep));
            return;
        }

        //In each step, we have two choices. We can either PICK the current number or we don't. Fisrt, pick the current number and then move on to the next index by recursively calling the Backtracking function.
        subsetsFromPreviousStep.Add(nums[index]);
        Backtracking(subsets, subsetsFromPreviousStep, nums, index + 1);

        //Since we don't want any duplicate values to be included, so we will move on to the next index which is not the value we included in the previous step i.e. nums[index] != nums[index + 1]
        while (index + 1 < nums.Length && nums[index] == nums[index + 1])
            index++;

        subsetsFromPreviousStep.RemoveAt(subsetsFromPreviousStep.Count - 1); //Remove last element because we have already picked it, now we don't want to include it in the following subsets
        Backtracking(subsets, subsetsFromPreviousStep, nums, index + 1);
    }
}