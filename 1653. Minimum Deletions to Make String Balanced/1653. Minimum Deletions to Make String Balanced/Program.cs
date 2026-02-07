Console.WriteLine(new Solution().MinimumDeletions("aababbab"));
Console.ReadLine();

public class Solution
{
    public int MinimumDeletions(string s)
    {
        int minimumDeletion = s.Length; // Worst case, we need to delete all characters
        int[] bBeforeCount = new int[s.Length];
        int[] aAfterCount = new int[s.Length];

        // Calculate the number of 'b's before each index and the number of 'a's after each index
        for (int left = 1, right = s.Length - 2; left < s.Length; left++, right--)
        {
            bBeforeCount[left] = bBeforeCount[left - 1] + (s[left - 1] == 'b' ? 1 : 0); // Count of 'b's before index left. The logic is that if the character at index left - 1 is 'b', we add 1 to the count of 'b's before index left, otherwise we keep the count the same as the previous index. This way, bBeforeCount[left] will give us the total number of 'b's that appear before index left in the string.
            aAfterCount[right] = aAfterCount[right + 1] + (s[right + 1] == 'a' ? 1 : 0); // Count of 'a's after index right. The logic is similar to bBeforeCount, but in reverse. If the character at index right + 1 is 'a', we add 1 to the count of 'a's after index right, otherwise we keep the count the same as the next index. This way, aAfterCount[right] will give us the total number of 'a's that appear after index right in the string.
        }

        for (int index = 0; index < s.Length; index++)
            minimumDeletion = Math.Min(minimumDeletion, aAfterCount[index] + bBeforeCount[index]); // Deletions needed to remove all 'a's after index and all 'b's before index. The index itself can be either 'a' or 'b', so we don't need to consider it separately. The logic is that if we choose to split the string at index, we would need to delete all 'b's before index and all 'a's after index to make the string balanced. For example, if index is 3, we would need to delete all 'b's before index (which are counted in bBeforeCount[3]) and all 'a's after index (which are counted in aAfterCount[3]) to ensure that all 'a's are on the left side and all 'b's are on the right side of the split.

        return minimumDeletion;
    }
}