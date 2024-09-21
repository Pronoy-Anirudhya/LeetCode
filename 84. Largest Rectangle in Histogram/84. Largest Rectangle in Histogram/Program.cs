Console.WriteLine(new Solution().LargestRectangleArea([2, 1, 5, 6, 2, 3]));
Console.ReadLine();

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = int.MinValue, lengthOfHeights = heights.Length;
        Stack<(int index, int height)> monotonicIncreasingStack = [];

        for (int index = 0; index < lengthOfHeights; index++)
        {
            int currentHeight = heights[index], leftIndex = index;

            //If the current height is smaller than the latest one in the stack, that means we can't extend the latest height in the stack further to form a rectangle. So we pop it and calculate the area for it and keep doing it until we find a latest height in the stack that is smaller than the current height. While doing so, we keep track of the index of the popped heights so that we can assign it to the index of the current height's index. Because, we can extend the current height up to the last popped element to form a rectangle.
            while (monotonicIncreasingStack.Count > 0 && monotonicIncreasingStack.Peek().height > currentHeight)
            {
                var leftElement = monotonicIncreasingStack.Pop();
                int currentArea = leftElement.height * (index - leftElement.index);
                maxArea = Math.Max(maxArea, currentArea);
                leftIndex = leftElement.index;
            }

            monotonicIncreasingStack.Push((leftIndex, currentHeight));
        }

        //Now the monotonic increasing stack would have the heights in increasing way. So the latest height can only form a rectangle in in the right side, up to the actual length of the array. Since in the left side, it would always have a smaller height, so we can't extend it to the left side further (Even if the leftmost height is equal, which it can be, we may only consider the right side because the left value will also calculate it's area anyway). So we pop all the elements while calculating the area for them.
        while (monotonicIncreasingStack.Count > 0)
        {
            var currentElement = monotonicIncreasingStack.Pop();
            int currentArea = currentElement.height * (lengthOfHeights - currentElement.index);
            maxArea = Math.Max(maxArea, currentArea);
        }

        return maxArea;
    }
}