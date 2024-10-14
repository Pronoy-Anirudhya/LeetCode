Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public long MaxKelements(int[] nums, int k)
    {
        long answer = 0;
        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        for (int index = 0; index < nums.Length; index++)
            maxHeap.Enqueue(nums[index], nums[index]);

        while (k-- > 0 && maxHeap.Count > 0)
        {
            int currentElement = maxHeap.Dequeue();
            answer += currentElement;
            currentElement = (int)Math.Ceiling((decimal)currentElement / 3);
            maxHeap.Enqueue(currentElement, currentElement);
        }

        return answer;
    }
}