Console.WriteLine(new Solution().MaxDistance([[-10, -9, -9, -3, -1, -1, 0], [-5], [4], [-8], [-9, -6, -5, -4, -2, 2, 3], [-3, -3, -2, -1, 0]]));
Console.ReadLine();

public class Solution
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        var maxDistance = -1;
        var previousMinimumNumber = arrays[0][0];
        var previousMaximumNumber = arrays[0][arrays[0].Count - 1];

        for (int i = 1; i < arrays.Count; i++)
        {
            var currentMinimumNumber = arrays[i][0];
            var currentMaximumNumber = arrays[i][arrays[i].Count - 1];

            var maxDistanceForCurrentMinimumNumber = previousMaximumNumber - currentMinimumNumber;
            var maxDistanceForCurrentMaximumNumber = currentMaximumNumber - previousMinimumNumber;

            var currentMaxDistance = Math.Max(maxDistanceForCurrentMinimumNumber, maxDistanceForCurrentMaximumNumber);
            maxDistance = Math.Max(maxDistance, currentMaxDistance);

            previousMinimumNumber = Math.Min(previousMinimumNumber, currentMinimumNumber);
            previousMaximumNumber = Math.Max(previousMaximumNumber, currentMaximumNumber);
        }

        return maxDistance;
    }
}