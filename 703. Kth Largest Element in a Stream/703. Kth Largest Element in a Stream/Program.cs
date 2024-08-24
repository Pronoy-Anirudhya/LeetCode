var kthLargestElement = new KthLargest(3, [4, 5, 8, 2]);
Console.WriteLine(kthLargestElement.Add(3));
Console.WriteLine(kthLargestElement.Add(5));
Console.WriteLine(kthLargestElement.Add(10));
Console.WriteLine(kthLargestElement.Add(9));
Console.WriteLine(kthLargestElement.Add(4));
Console.ReadLine();

public class KthLargest
{
    private readonly int[] Nums;
    private readonly int kthValue;
    private readonly PriorityQueue<int, int> minHeap;

    public KthLargest(int k, int[] nums)
    {
        Nums = nums;
        kthValue = k;
        minHeap = new PriorityQueue<int, int>();

        foreach (int num in Nums)
            minHeap.Enqueue(num, num);
    }

    public int Add(int val)
    {
        minHeap.Enqueue(val, val);

        if(minHeap.Count > kthValue)
            while(minHeap.Count != kthValue)
                minHeap.Dequeue();

        return minHeap.Peek();
    }
}