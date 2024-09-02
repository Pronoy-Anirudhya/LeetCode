Console.WriteLine(new Solution().ChalkReplacer([3, 4, 1, 2], 25));
Console.ReadLine();

public class Solution
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        var prefixSum = new long[chalk.Length];
        long totalChalks = 0;

        for (int i = 0; i < chalk.Length; i++)
        {
            totalChalks += chalk[i];
            prefixSum[i] = totalChalks;
        }

        if (totalChalks % k == 0)
            return 0;

        long remainingChalks = k;

        /*
         * If we have more remaining chalks than total chalks, then we can get the actual remaining chalks by getting the remainder e.g. k=25, totalChalk=10, so remainingChalks = 25%10 = 5
         * Else when we have more total chalks than remaining, that means we can not even complete one full cycle, so keep k as remaining chalks (that's why we assigned remainingChalks=k to get rid of the else block) e.g. k=8, totalChalk=10, so we can actually go up to index 2 and then k will be 0 and answer would be 3.
         */
        if (remainingChalks > totalChalks)
            remainingChalks = k % totalChalks;

        var left = 0;
        var right = chalk.Length - 1;

        while (left <= right)
        {
            var mid = left + ((right - left) / 2);
            var totalChalksUptoMid = prefixSum[mid];

            if (totalChalksUptoMid == remainingChalks)
                return ++mid; //If they are equal, it means we can go up to mid index and then our k will become 0. We need to increment k before returning since from mid+1 index, students will not be able to solve the problem

            if (remainingChalks > totalChalksUptoMid)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left; //After the binary search, left will be the index from when students will not be able to solve the problem
    }
}