Console.WriteLine(new Solution().CombinationSum([2, 3, 6, 7], 7));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> validCombinations = [];
        List<int> combinationFromPreviousStep = [];
        int sumFromPreviousStep = 0;

        DFSBacktracking(validCombinations, combinationFromPreviousStep, candidates, target, sumFromPreviousStep, 0);
        return validCombinations;
    }

    private void DFSBacktracking(List<IList<int>> validCombinations, List<int> combinationFromPreviousStep, int[] candidates, int target, int sumFromPreviousStep, int index)
    {
        if (sumFromPreviousStep == target)
        {
            validCombinations.Add(new List<int>(combinationFromPreviousStep));
            return;
        }

        if (index >= candidates.Length || sumFromPreviousStep > target)
            return;

        int candidate = candidates[index];
        sumFromPreviousStep += candidate;
        combinationFromPreviousStep.Add(candidate);
        DFSBacktracking(validCombinations, combinationFromPreviousStep, candidates, target, sumFromPreviousStep, index);

        sumFromPreviousStep -= candidate;
        combinationFromPreviousStep.RemoveAt(combinationFromPreviousStep.Count - 1);
        DFSBacktracking(validCombinations, combinationFromPreviousStep, candidates, target, sumFromPreviousStep, index + 1);
    }
}