Console.WriteLine(new Solution().HIndex([2, 2]));
Console.ReadLine();

public class Solution
{
    public int HIndex(int[] citations)
    {
        var hIndex = 0;
        var left = 0;
        var right = citations.Length - 1;

        while (left <= right)
        {
            var mid = left + ((right - left) / 2);
            var paperCitedMoreOrEqualThanMid = citations.Length - mid;
            var citationCount = citations[mid];

            if (citationCount >= paperCitedMoreOrEqualThanMid)
            {
                hIndex = paperCitedMoreOrEqualThanMid;
                right = --mid;
            }
            else
                left = ++mid;
        }

        return hIndex;
    }
}