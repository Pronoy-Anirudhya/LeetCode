Console.WriteLine(new Solution().Permute([1, 2, 3]));
Console.ReadLine();

public class Solution
{
    public int Count = 1;

    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> permutations = [];
        Backtracking(permutations, [], nums);
        return permutations;
    }

    private void Backtracking(IList<IList<int>> result, List<int> resultUntilNow, int[] nums)
    {
        if (resultUntilNow.Count == nums.Length)
        {
            result.Add(new List<int>(resultUntilNow));
            return;
        }

        foreach (int number in nums)
        {
            if (resultUntilNow.Contains(number))
                continue;

            resultUntilNow.Add(number);
            Backtracking(result, resultUntilNow, nums);
            resultUntilNow.Remove(number);
        }
    }
}