Console.WriteLine(new Solution().KthSmallestPrimeFraction([1, 2, 3, 5], 3));
Console.ReadLine();

public class Solution
{
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        //Naive O(N^2logK) Solution. Revisit to solve it with optimization by leveraging the fact that the array is SORTED!
        PriorityQueue<(int, int), double> maxHeap = new(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        for (int item1Index = 0; item1Index < arr.Length; item1Index++)
        {
            for (int item2Index = item1Index + 1; item2Index < arr.Length; item2Index++)
            {
                double fraction = (double)(arr[item1Index]) / arr[item2Index];
                maxHeap.Enqueue((arr[item1Index], arr[item2Index]), fraction);

                if (maxHeap.Count > k)
                    maxHeap.Dequeue();
            }
        }

        return [maxHeap.Peek().Item1, maxHeap.Peek().Item2];
    }
}