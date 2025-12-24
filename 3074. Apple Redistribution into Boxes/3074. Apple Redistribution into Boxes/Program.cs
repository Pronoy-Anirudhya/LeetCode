Console.WriteLine(new Solution().MinimumBoxes([9, 8, 8, 2, 3, 1, 6], [10, 1, 4, 10, 8, 5]));
Console.ReadLine();

public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        int boxUsed = 0, totalApple = 0;
        Array.Sort(capacity, (a, b) => b.CompareTo(a)); // Sort capacity in descending order to use larger boxes first. This helps minimize the number of boxes used.

        foreach (int applesInPack in apple)
            totalApple += applesInPack; // Calculate total number of apples. This is the total amount we need to fit into boxes.

        foreach (int box in capacity)
        {
            // If we have already fit all apples into boxes, we can stop.
            if (totalApple <= 0)
                break;

            // Use this box to fit apples. Decrease the total apples by the box capacity and increment the box count.
            totalApple -= box;
            boxUsed++;
        }

        return boxUsed;
    }
}