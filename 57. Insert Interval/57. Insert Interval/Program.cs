var i1 = new int[] { 1, 2 };
var i2 = new int[] { 3, 5 };
var i3 = new int[] { 6, 7 };
var i4 = new int[] { 8, 10 };
var i5 = new int[] { 12, 16 };
var intervals = new int[][] { i1, i2, i3, i4, i5 };
Console.WriteLine(new Solution().Insert(intervals, [4, 8]));
Console.ReadLine();

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        var newIntervalLeft = newInterval[0];
        var newIntervalRight = newInterval[1];

        if (intervals.Length == 0)
            result.Add(newInterval);

        else if (intervals.Length == 1)
        {
            var existingIntervalLeft = intervals[0][0];
            var existingIntervalRight = intervals[0][1];

            if (newIntervalLeft > existingIntervalRight)
            {
                result.Add(intervals[0]);
                result.Add(newInterval);
            }
            else if (newIntervalRight < existingIntervalLeft)
            {
                result.Add(newInterval);
                result.Add(intervals[0]);
            }
            else
            {
                var resultIntervalLeft = newIntervalLeft <= existingIntervalLeft ? newIntervalLeft : existingIntervalLeft;
                var resultIntervalRight = newIntervalRight >= existingIntervalRight ? newIntervalRight : existingIntervalRight;

                result.Add([resultIntervalLeft, resultIntervalRight]);
            }
        }
        else
        {
            var left = 0;
            var right = 1;
            var resultLeft = 0;
            var resultRight = 0;

            while (right < intervals.Length)
            {
                var currentWindowFirstLeft = intervals[left][0];
                var currentWindowSecondLeft = intervals[right][0];

                if (newIntervalLeft > currentWindowSecondLeft)
                {
                    result.Add(intervals[left]);
                    left++;
                    right++;
                }
                else if (newIntervalLeft < currentWindowFirstLeft)
                {
                    resultLeft = newIntervalLeft;
                    break;
                }
                else if (currentWindowFirstLeft >= newIntervalLeft && newIntervalLeft <= currentWindowSecondLeft)
                {
                    resultLeft = currentWindowFirstLeft;
                    break;
                }
            }

            while (right < intervals.Length)
            {
                var currentWindowFirstRight = intervals[left][1];
                var currentWindowSecondRight = intervals[right][1];

                if (newIntervalRight > currentWindowSecondRight)
                {
                    result.Add(intervals[left]);
                    left++;
                    right++;
                }
                else if (newIntervalLeft < currentWindowFirstRight)
                {
                    resultLeft = newIntervalLeft;
                    break;
                }
                else if (currentWindowFirstRight >= newIntervalLeft && newIntervalLeft <= currentWindowSecondRight)
                {
                    resultLeft = currentWindowFirstRight;
                    break;
                }
            }
        }

        return result.ToArray();
    }
}