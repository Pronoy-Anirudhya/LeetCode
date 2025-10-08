Console.WriteLine(new Solution().SuccessfulPairs([3, 1, 2], [8, 5, 8], 16));
Console.ReadLine();

public class Solution
{
    //Intuition: For each spell, we need to find how many potions can form a successful pair with it.  A pair is successful if the product of the spell's strength and the potion's strength is at least 'success'. To efficiently find the count of such potions for each spell, we can sort the potions array and use binary search to quickly locate the first potion that, when multiplied by the spell's strength, meets or exceeds the 'success' threshold. The number of successful pairs for that spell will then be the total number of potions minus the index found by the binary search.
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        int[] result = new int[spells.Length];
        Array.Sort(potions); //Sorting potions to use binary search.

        for (int index = 0; index < spells.Length; index++)
            result[index] = BinarySearchToGetSuccessfulPairCount(potions, spells[index], success);

        return result;
    }

    // Binary search to find the count of potions that can form a successful pair with the given spell. Look for a potentially smaller potion that still meets the criteria. We move the right pointer to mid - 1 to continue searching in the left half of the array. This is because we want to find the first potion that can form a successful pair with the spell, and there might be smaller potions that also meet the criteria. By moving the right pointer, we ensure that we don't miss any potential candidates in the left half of the array. We continue this process until the left pointer surpasses the right pointer, at which point the left pointer will be at the position of the first potion that can form a successful pair with the spell. This allows us to efficiently count the number of successful pairs by subtracting the left pointer from the total number of potions.
    private int BinarySearchToGetSuccessfulPairCount(int[] potions, int spell, long target)
    {
        int left = 0, right = potions.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            long product = (long)potions[mid] * spell;

            // If the product is greater than or equal to the target, we need to search in the left half to find a potentially smaller potion that still meets the criteria. Otherwise, we search in the right half. This way, we can efficiently narrow down the range of potions to find the first one that forms a successful pair with the spell.
            if (product >= target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return potions.Length - left; // Count of potions that can form a successful pair with the spell. All potions from index 'left' to the end of the array will form successful pairs with the spell. Thus, the count is the total number of potions minus 'left'.
    }
}