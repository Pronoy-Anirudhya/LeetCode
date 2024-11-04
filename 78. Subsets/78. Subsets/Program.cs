Console.WriteLine(new Solution().Subsets([1, 2, 3]));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> subsets = [];
        List<int> setFromPreviousStep = [];

        DFSBacktracking(subsets, setFromPreviousStep, nums, 0);
        return subsets;
    }

    /*
    Idea behind Backtracking Approach/Solution: We have two choices (in general for Backtracking solutions) to create a Subset of nums. Either add the next number (index + 1) to the set or add empty/null value for each step. So first we will add the next number recursively until we reach the end when we meet the base case and add the set to the result. And then we will add the empty/null value to the set in the same way. For nums = [1, 2], lets say we have [1] in some step. Now we went down and added 2 in the list and eventually it returned through the base case. Now the set is [1, 2]. In the next line, we want to choose the second option of adding empty value to [1]. Thats why we are removing the last element.
    */
    private void DFSBacktracking(List<IList<int>> subsets, List<int> setFromPreviousStep, int[] nums, int index)
    {
        if (index >= nums.Length)
        {
            subsets.Add(new List<int>(setFromPreviousStep));//THIS IS IMPORTANT! We are continuously updating (adding/deleting) the setFromPreviousStep. Since list is "pass by reference", so if we didn't create a new list and copied the setFromPreviousStep build up to this point in the subsets, subsets would have changed also when we are updating the setFromPreviousStep as we go. So doing subsets.Add(setFromPreviousStep) would give us a list of 8 lists with 0 numbers in each of them since at the last, setFromPreviousStep has 0 numbers. That's why it is imperative that we copy the values of setFromPreviousStep into subsets rather than just adding the "REFERENCE" of setFromPreviousStep.
            return;
        }

        //Add the number at the current index to the setFromPreviousStep and then recursively add the numbers until we reach the end.
        setFromPreviousStep.Add(nums[index]);
        DFSBacktracking(subsets, setFromPreviousStep, nums, index + 1);

        //Since we added the number at the current index before we started recursively adding all the numbers to the setFromPreviousStep, so we have to remove the last number in the set to mimic the second choice of not adding the number at the current index by removing the last number from the setFromPreviousStep. And then recursively add the numbers until we reach the end.
        setFromPreviousStep.RemoveAt(setFromPreviousStep.Count - 1);
        DFSBacktracking(subsets, setFromPreviousStep, nums, index + 1);
    }
}