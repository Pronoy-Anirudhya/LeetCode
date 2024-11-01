MedianFinder medianFinder = new MedianFinder();
medianFinder.AddNum(1);    // arr = [1]
medianFinder.AddNum(2);    // arr = [1, 2]
Console.WriteLine(medianFinder.FindMedian()); // return 1.5 (i.e., (1 + 2) / 2)
medianFinder.AddNum(3);    // arr[1, 2, 3]
Console.WriteLine(medianFinder.FindMedian()); // return 2.0

Console.ReadLine();

public class MedianFinder
{
    private PriorityQueue<int, int> maxHeapFirstHalf, minHeapLastHalf;//We will preserve the data stream coming through AddNum in two halves. First half will be maxHeap since we want the median and that is the last element of the half. So keeping it maxHeap would give us the last element. And for last half, we want the starting number of that half which is why minHeap (minimum number will be at the top of the queue). e.g. [1, 2] & [3, 4]

    public MedianFinder()
    {
        maxHeapFirstHalf = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        minHeapLastHalf = new();
    }

    public void AddNum(int num)
    {
        if (maxHeapFirstHalf.Count == minHeapLastHalf.Count)
            maxHeapFirstHalf.Enqueue(num, num);
        else
            minHeapLastHalf.Enqueue(num, num);

        //Top of first half (max number of that half) will have to be smaller or equal to the first number of last half (smallest of that half).
        while (maxHeapFirstHalf.Count > 0 && minHeapLastHalf.Count > 0 && maxHeapFirstHalf.Peek() > minHeapLastHalf.Peek())
        {
            int firstHalfNumber = maxHeapFirstHalf.Dequeue(), lastHalfNumber = minHeapLastHalf.Dequeue();
            maxHeapFirstHalf.Enqueue(lastHalfNumber, lastHalfNumber);
            minHeapLastHalf.Enqueue(firstHalfNumber, firstHalfNumber);
        }
    }

    public double FindMedian()
    {
        double median = 0;
        int streamDataCount = minHeapLastHalf.Count + maxHeapFirstHalf.Count;

        if (streamDataCount % 2 == 0)
        {
            int medianValue = maxHeapFirstHalf.Peek() + minHeapLastHalf.Peek();
            median = (double)(medianValue / 2d);
        }
        else
        {
            median = maxHeapFirstHalf.Peek();
        }

        return median;
    }
}