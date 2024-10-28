Console.WriteLine(new Solution().LastStoneWeight([2, 7, 4, 1, 8, 1]));
Console.ReadLine();

public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> maxHeapStoneWeight = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (int stone in stones)
            maxHeapStoneWeight.Enqueue(stone, stone);

        while (maxHeapStoneWeight.Count > 1)
        {
            int maxStoneWeight = maxHeapStoneWeight.Dequeue(), secondMaxStoneWeight = maxHeapStoneWeight.Dequeue();

            if (maxStoneWeight != secondMaxStoneWeight)
            {
                int newStoneWeight = maxStoneWeight - secondMaxStoneWeight;
                maxHeapStoneWeight.Enqueue(newStoneWeight, newStoneWeight);
            }
        }

        return maxHeapStoneWeight.Count == 1 ? maxHeapStoneWeight.Dequeue() : 0;
    }
}