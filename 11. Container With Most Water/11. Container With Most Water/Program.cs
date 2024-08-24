var heights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
Console.WriteLine(new Solution().MaxArea(heights));
Console.ReadLine();

public class Solution
{
    public int MaxArea(int[] height)
    {
        var maxArea = 0;
        var leftPointer = 0;
        var rightPointer = height.Length - 1;

        while (leftPointer < rightPointer)
        {
            var side = Math.Min(height[leftPointer], height[rightPointer]);
            var distance = rightPointer - leftPointer;
            var area = side * distance;
            maxArea = Math.Max(maxArea, area);

            if (height[leftPointer] < height[rightPointer])
                leftPointer++;
            else
                rightPointer--;
        }

        return maxArea;
    }
}