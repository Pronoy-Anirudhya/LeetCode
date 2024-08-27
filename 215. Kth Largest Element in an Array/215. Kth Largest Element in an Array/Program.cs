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
		
		//Another way of writing MinHeap
        /*var minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a - b));

        foreach (int num in nums)
        {
            if (minHeap.Count == k)
            {
                if (num > minHeap.Peek())
                    minHeap.DequeueEnqueue(num, num);
            }
            else
                minHeap.Enqueue(num, num);
        }

        return minHeap.Peek();*/
    }
}