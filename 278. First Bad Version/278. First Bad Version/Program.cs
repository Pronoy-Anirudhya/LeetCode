Console.WriteLine(new Solution().FirstBadVersion(3));
Console.ReadLine();

public class Solution
{
    public int FirstBadVersion(int n)
    {
        var left = 1;
        var right = n;
        var firstBadVersion = 0;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var isBadVersion = IsBadVersion(middle);

            if (isBadVersion)
            {
                right = middle - 1;
                firstBadVersion = middle;
            }
            else if (!isBadVersion)
                left = middle + 1;
        }

        return firstBadVersion;
    }

    public bool IsBadVersion(int version)
    {
        return version == 2 || version == 3;
    }
}