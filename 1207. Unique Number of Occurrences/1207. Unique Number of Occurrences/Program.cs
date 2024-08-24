Console.WriteLine(new Solution().UniqueOccurrences(new int[] { 1, 2, 2, 1, 1, 3 }));
Console.ReadLine();

public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> countMap = new Dictionary<int, int>();

        foreach (int num in arr)
        {
            if (countMap.ContainsKey(num))
                countMap[num]++;
            else
                countMap[num] = 0;
        }

        foreach (int count in countMap.Values)
        {
            if (arr[count] == -1001)
                return false;

            arr[count] = -1001;
        }


        return true;
    }
}