Console.WriteLine(new Solution().MaxSlidingWindow([1, 3, 1, 2, 0, 5], 3));
Console.ReadLine();

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] maxInEachSlidingWindow = new int[nums.Length - k + 1];

        //MaxHeap Solution. Time Complexity: O(nLogk)
        /*PriorityQueue<(int number, int index), int> maxHeap = new(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        int left = 0, maxArrayIndex = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            int currentNumber = nums[right];

            //Since we want to find the MAX from each window, so there's no point keep any number that is smaller than the current number we trying to add to the window. Also, if any number is out of the windoe (< leftIndex), we will remove them too.
            while (maxHeap.Count > 0 && (maxHeap.Peek().number < currentNumber || maxHeap.Peek().index < left))
                maxHeap.Dequeue();

            maxHeap.Enqueue((currentNumber, right), currentNumber);
            int currentSlidingWindowLength = right - left + 1;

            if (currentSlidingWindowLength == k)
            {
                maxInEachSlidingWindow[maxArrayIndex] = maxHeap.Peek().number;
                left++;
                maxArrayIndex++;
            }
        }*/

        //Deque (Double-ended Queue) Solution: Time Complexity: O(n)
        LinkedList<(int number, int index)> deque = []; //We can use just int to store the index instead of tuple. But that's too tricky to come up with during an interview session. Tuple is more intuitive even if it costs a little extra MS in time.
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            int currentNumber = nums[right];

            //Since we want to find the MAX from each window, so there's no point keep any number that is smaller than the current number we trying to add to the window.
            while (deque.Count > 0 && deque.Last.Value.number < currentNumber)
                deque.RemoveLast();

            //If any number is out of the windoe(< leftIndex), we will remove them too.
            if (deque.Count > 0 && deque.First.Value.index < left)
                deque.RemoveFirst();

            deque.AddLast((currentNumber, right));
            int currentSlidingWindowLength = right - left + 1;

            if (currentSlidingWindowLength == k)
            {
                maxInEachSlidingWindow[left] = deque.First.Value.number;
                left++;
            }
        }

        return maxInEachSlidingWindow;
    }
}