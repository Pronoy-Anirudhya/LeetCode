Console.WriteLine(new Solution().AvoidFlood([0, 1, 1]));
Console.ReadLine();

public class Solution
{
    /*
     * Intuition: We need to keep track of the days when it rains on a lake and the days when we can dry a lake. We can use these days to dry a lake. We need to find the smallest index in this set that is greater than the last day it rained on a lake. We can use a SortedSet to efficiently find the smallest index greater than a given value. We can use the GetViewBetween method to get a view of the set that contains only the elements greater than the given value. Then we can get the minimum element from this view. If the view is empty, it means there are no dry days after the last day it rained on the lake, so we cannot avoid a flood. We can also use a Dictionary to store the last day it rained on each lake. This way, we can quickly check if it has rained on a lake before and get the last day it rained on that lake.
    */
    public int[] AvoidFlood(int[] rains)
    {
        int[] result = new int[rains.Length];
        SortedSet<int> dryDays = []; // Stores the indices of the days when it doesn't rain
        Dictionary<int, int> lastRainedDayMap = []; // Maps lake number to the last day it rained on that lake

        for (int index = 0; index < rains.Length; index++)
        {
            int lakeNumber = rains[index];

            // It didn't rain on this day, so we can dry a lake. We will decide which lake to dry later. For now, we can just add this day to the set of dry days. We can also set the result for this day to 1, as we can dry any lake on this day. The actual lake to dry will be determined later when we find a lake that needs to be dried.
            if (lakeNumber == 0)
            {
                dryDays.Add(index);
                result[index] = 1; // We can dry any lake on this day. The actual lake to dry will be determined later.
                continue;
            }

            // It rained on this lake. We need to check if it has rained on this lake before. If it has, we need to find a dry day after the last day it rained on this lake to dry it. If we cannot find such a day, we cannot avoid a flood.
            if (!lastRainedDayMap.TryGetValue(lakeNumber, out int lastRainedDay))
            {
                result[index] = -1;
                lastRainedDayMap.Add(lakeNumber, index);
                continue;
            }

            // It has rained on this lake before. We need to find a dry day after the last day it rained on this lake to dry it.
            if (dryDays.Count == 0)
                return [];

            // If the last day it rained on this lake is greater than the maximum dry day, we cannot find a dry day after it rained on this lake to dry it.
            if (lastRainedDay > dryDays.Max)
                return [];

            // We can use the GetViewBetween method to get a view of the set that contains only the elements greater than the last day it rained on this lake. Then we can get the minimum element from this view. This will be the dry day after it rained on this lake that we can use to dry it.
            var view = dryDays.GetViewBetween(lastRainedDay, dryDays.Max);
            int dryDayIndexAfterItRainedOnThisLake = view != null ? view.Min : -1;

            // If the view is empty, it means there are no dry days after the last day it rained on the lake, so we cannot avoid a flood.
            if (dryDayIndexAfterItRainedOnThisLake == -1)
                return [];

            result[index] = -1;
            result[dryDayIndexAfterItRainedOnThisLake] = lakeNumber; // We will dry this lake on the dry day we found
            dryDays.Remove(dryDayIndexAfterItRainedOnThisLake); // Remove this dry day from the set of dry days as we have used it to dry a lake.
            lastRainedDayMap[lakeNumber] = index; // Update the last day it rained on this lake to the current day.
        }

        return result;
    }
}