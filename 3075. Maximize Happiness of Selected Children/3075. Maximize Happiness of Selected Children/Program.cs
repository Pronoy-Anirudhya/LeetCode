Console.WriteLine(new Solution().MaximumHappinessSum([2, 3, 4, 5], 1));
Console.ReadLine();

public class Solution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        long maximumHappiness = 0;
        int turn = 0;
        Array.Sort(happiness, (a, b) => b.CompareTo(a)); // Sort in descending order. Since we want to maximize happiness.

        while (turn < k)
        {
            int currentHappiness = happiness[turn] - turn; // Decrease happiness by turn number. It represents the number of turns passed.

            // If current happiness is negative, break the loop as further turns will only decrease happiness.
            if (currentHappiness < 0)
                break;

            maximumHappiness += currentHappiness;
            turn++;
        }

        return maximumHappiness;
    }
}