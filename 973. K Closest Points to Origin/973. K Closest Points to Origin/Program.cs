Console.WriteLine(new Solution().KClosest([[2, 2], [2, 2], [2, 2], [2, 2], [2, 2], [2, 2], [1, 1]], 1));
Console.ReadLine();

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var kClosestPoints = new int[k][];
        var maxHeap = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (int i = 0; i < points.Length; i++ )
        {
            var distance = (int)(Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
            maxHeap.Enqueue(points[i], distance);

            if (i >= k)
                maxHeap.Dequeue();
        }

        for (int i = 0; i < k; i++)
            kClosestPoints[i] = maxHeap.Dequeue();

        return kClosestPoints;
    }
}