Console.WriteLine(new Solution().TopKFrequent(["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], 4));
Console.ReadLine();

public class Solution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var topKFrequentWords = new string[k];
        var wordFrequency = new Dictionary<string, int>();
        var minHeap = new PriorityQueue<string, KeyValuePair<string, int>>(new NameComparer());

        foreach (var word in words)
            if (!wordFrequency.TryAdd(word, 1))
                wordFrequency[word]++;

        var currentHeapCapacity = 0;

        foreach (var frequencyDict in wordFrequency)
        {
            minHeap.Enqueue(frequencyDict.Key, frequencyDict);
            currentHeapCapacity += 1;

            if (currentHeapCapacity > k)
                minHeap.Dequeue();
        }

        for (int i = topKFrequentWords.Length - 1; i >= 0; i--)
            topKFrequentWords[i] = minHeap.Dequeue();

        return topKFrequentWords;
    }

    public class NameComparer : IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y) =>
            (x.Value == y.Value) ? (y.Key.CompareTo(x.Key)) : (x.Value - y.Value);
    }
}