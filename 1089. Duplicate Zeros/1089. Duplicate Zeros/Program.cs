new Solution().DuplicateZeros([1, 0, 2, 3, 0, 4, 5, 0]);
Console.ReadLine();

public class Solution
{
    public void DuplicateZeros(int[] arr)
    {
        bool isDuplicateZeroNeeded = false; // Indicates whether the next element should be a duplicated zero.
        Queue<int> queue = []; // Queue to hold elements that need to be shifted.

        for (int index = 0; index < arr.Length; index++)
        {
            // If a zero duplication is needed, insert a zero at the current index. It will push the rest of the elements to the right. And we reset the flag. This step takes precedence over normal processing.
            if (isDuplicateZeroNeeded)
            {
                queue.Enqueue(arr[index]); // Enqueue the current element to be processed later.
                arr[index] = 0;
                isDuplicateZeroNeeded = false; // Reset the flag after duplicating zero.
                continue; // Move to the next index.
            }

            int currentNumber;

            // If there are elements in the queue, dequeue the front element to place it at the current index. Otherwise, take the current element from the array.
            if (queue.Count > 0)
            {
                queue.Enqueue(arr[index]); // Enqueue the current element to be processed later.
                currentNumber = queue.Dequeue();
            }
            else
                currentNumber = arr[index];

            // If the current number is zero, set the flag to indicate that the next element should be a duplicated zero.
            if (currentNumber == 0)
                isDuplicateZeroNeeded = true;

            arr[index] = currentNumber;
        }
    }
}