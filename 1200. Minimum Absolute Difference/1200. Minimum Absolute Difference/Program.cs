Console.WriteLine(new Solution().MinimumAbsDifference([4, 2, 1, 3]));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        IList<IList<int>> result = [];
        int minimumDifference = int.MaxValue;
        Array.Sort(arr); // Sort the array to find minimum differences between consecutive elements. This is because the smallest differences will always be between adjacent elements in a sorted array.

        // Iterate through the sorted array to find the minimum absolute difference. We only need to check consecutive elements since the array is sorted. We are starting from index 1 to compare each element with its predecessor. We calculate the difference and update the minimum difference and result list accordingly.
        for (int index = 1; index < arr.Length; index++)
        {
            int currentDifference = arr[index] - arr[index - 1];

            // If the current difference is less than the minimum found so far, update the minimum and reset the result list.
            if (currentDifference < minimumDifference)
            {
                minimumDifference = currentDifference;
                result.Clear(); // Clear previous results as we found a new minimum difference.
                result.Add([arr[index - 1], arr[index]]);
            }
            else if (currentDifference == minimumDifference) // If the current difference equals the minimum, add the pair to the result list.
            {
                result.Add([arr[index - 1], arr[index]]);
            }
        }

        return result;
    }
}