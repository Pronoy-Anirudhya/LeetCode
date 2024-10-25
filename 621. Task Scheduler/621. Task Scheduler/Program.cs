Console.WriteLine(new Solution().LeastInterval(['A', 'A', 'B', 'B'], 2));
Console.ReadLine();

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int interval = 1;
        Dictionary<char, int> taskFrequency = [];
        PriorityQueue<int, int> maxHeapFrequency = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));//We just need to add the task frequency in the maxHeap, we don't necessariliy need to know which task (character) the frequency belongs to.
        Queue<(int frequency, int lastStartInterval)> processedTaskQueue = [];

        foreach (char task in tasks)
        {
            if (!taskFrequency.TryAdd(task, 1))
                taskFrequency[task]++;
        }

        foreach (var frequency in taskFrequency)
            maxHeapFrequency.Enqueue(frequency.Value, frequency.Value);

        //We have to keep going until either of these queues are non-empty. Since, there will be times when the processed queue will have tasks that will be available after n-intervals, in the meanwhile the heap could be empty which means it would be idle 
        while (maxHeapFrequency.Count > 0 || processedTaskQueue.Count > 0)
        {
            if (processedTaskQueue.Count > 0)
            {
                (int frequency, int lastStartInterval) = processedTaskQueue.Peek();
                var intervalElapsed = interval - lastStartInterval;

                if (intervalElapsed > n)
                {
                    maxHeapFrequency.Enqueue(frequency, frequency);
                    processedTaskQueue.Dequeue();
                }
            }

            if (maxHeapFrequency.Count > 0)
            {
                var currentMaxFrequency = maxHeapFrequency.Dequeue();

                //We will only enqueue the task if it's frequency after this time is not ZERO
                if ((currentMaxFrequency - 1) > 0)
                    processedTaskQueue.Enqueue((currentMaxFrequency - 1, interval));
            }

            //This extra logic is here for the last task. So when the last task is processed and both the queues are empty, that's the interval we want to return. So if we don't check before incrementing the interval each time, then for the last task, we would be accidentally adding another interval before it gets termintaed in the while logic.
            if (maxHeapFrequency.Count > 0 || processedTaskQueue.Count > 0)
                interval++;
        }

        return interval;
    }
}