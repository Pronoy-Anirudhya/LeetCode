var array1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
var array2 = new int[] { 2, 1, 4, 3, 9, 6 };

Console.WriteLine(string.Join(" ", new Solution().RelativeSortArray(array1, array2)));
Console.ReadLine();

public class Solution
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var relativeSortedList = new List<int>();
        var array2Map = new Dictionary<int, int>();
        var nonExistingList = new List<int>();
        var cumulativeCount = 0;

        for (int i = 0; i < arr2.Length; i++)
            array2Map.Add(arr2[i], 0);

        for (int i = 0; i < arr1.Length; i++)
        {
            if (!array2Map.ContainsKey(arr1[i]))
            {
                nonExistingList.Add(arr1[i]);
                continue;
            }

            array2Map[arr1[i]] = ++array2Map[arr1[i]];
        }

        foreach (var item in array2Map)
        {
            cumulativeCount += array2Map[item.Key];

            while (cumulativeCount > 0)
            {
                relativeSortedList.Add(item.Key);
                cumulativeCount--;
            }
        }

        nonExistingList.Sort();
        relativeSortedList.AddRange(nonExistingList);
        return relativeSortedList.ToArray();
    }
}