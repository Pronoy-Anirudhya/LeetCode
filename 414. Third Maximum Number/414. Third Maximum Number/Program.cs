Console.WriteLine(new Solution().ThirdMax([1, 2, 2, 5, 3, 5]));
Console.ReadLine();

public class Solution
{
    public int ThirdMax(int[] nums)
    {
        var sortedSet = new SortedSet<int>();

        foreach (var num in nums)
        {
            if (sortedSet.Count == 3)
            {
                if (num > sortedSet.ElementAt(0) && !sortedSet.Contains(num))
                {
                    sortedSet.Remove(sortedSet.ElementAt(0));
                    sortedSet.Add(num);
                }
            }
            else
                sortedSet.Add(num);
        }

        return sortedSet.Count == 3 ? sortedSet.ElementAt(0) : sortedSet.Last();
    }
}