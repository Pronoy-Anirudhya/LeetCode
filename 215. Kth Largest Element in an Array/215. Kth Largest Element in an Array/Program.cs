Console.WriteLine(new Solution().FindKthLargest([3, 2, 1, 5, 6, 4], 2));
Console.ReadLine();

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var minHeap = new PriorityQueue<int, int>();
        int index = 0;

        while (index < k)
        {
            minHeap.Enqueue(nums[index], nums[index]);
            index++;
        }

        for (int i = index; i < nums.Length; i++)
        {
            var heapRoot = minHeap.Peek();

            if (heapRoot >= nums[i])
                continue;

            minHeap.Dequeue();
            minHeap.Enqueue(nums[i], nums[i]);
        }

        return minHeap.Dequeue();
    }
}