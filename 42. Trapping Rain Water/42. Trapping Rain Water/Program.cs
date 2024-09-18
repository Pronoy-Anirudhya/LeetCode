Console.WriteLine(new Solution().Trap([0, 1, 0, 1]));
Console.ReadLine();

public class Solution
{
    public int Trap(int[] height)
    {
        int water = 0, left = 0, right = height.Length - 1, currentMinimumWindowHeight = 0;

        while (left < right)
        {
            int leftHeight = height[left];
            int rightHeight = height[right];
            currentMinimumWindowHeight = Math.Min(leftHeight, rightHeight);

            //Fix the side that has higher height since that might give you an opportunity to trap water. Increment the other side while calculating the amount of water it can trap until you get a higher height than the current minimum height. Do this until left and/or right crosses each other.
            if (leftHeight <= rightHeight)
            {
                left++;

                while (left < right && height[left] < currentMinimumWindowHeight)
                {
                    water += currentMinimumWindowHeight - height[left];
                    left++;
                }
            }
            else
            {
                right--;

                while (right > left && height[right] < currentMinimumWindowHeight)
                {
                    water += currentMinimumWindowHeight - height[right];
                    right--;
                }
            }
        }

        return water;
    }
}