Console.WriteLine(new Solution().KthDistinct(new string[] { "d", "b", "c", "b", "c", "a" }, 2));
Console.ReadLine();

public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        var kthDistincString = string.Empty;
        var stringDict = new Dictionary<string, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            var item = arr[i];

            if (!stringDict.ContainsKey(item))
                stringDict.Add(item, i);
            else
            {
                arr[stringDict[item]] = string.Empty;
                arr[i] = string.Empty;
                stringDict[item] = i;
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == string.Empty)
                continue;

            k--;

            if (k == 0)
            {
                kthDistincString = arr[i];
                break;
            }
        }

        return kthDistincString;
    }
}