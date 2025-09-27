Console.WriteLine(new Solution().LargestTriangleArea([[9, 0], [0, 2], [3, 1], [10, 8]]));
Console.ReadLine();

public class Solution
{
    public double LargestTriangleArea(int[][] points)
    {
        double largestTriangleArea = int.MinValue;

        for (int sideOneIndex = 0; sideOneIndex < points.Length - 2; sideOneIndex++)
        {
            for (int sideTwoIndex = sideOneIndex + 1; sideTwoIndex < points.Length - 1; sideTwoIndex++)
            {
                for (int sideThreeIndex = sideTwoIndex + 1; sideThreeIndex < points.Length; sideThreeIndex++)
                {
                    int[] sideOne = points[sideOneIndex], sideTwo = points[sideTwoIndex], sideThree = points[sideThreeIndex];
                    double currentTriangleArea = CalculateTriangleArea(sideOne, sideTwo, sideThree);
                    largestTriangleArea = Math.Max(largestTriangleArea, currentTriangleArea);
                }
            }
        }

        return largestTriangleArea;
    }

    // Using the Shoelace formula to calculate the area of a triangle given its vertices. The formula is: Area = 0.5 * |x1(y2 - y3) + x2(y3 - y1) + x3(y1 - y2)|
    private double CalculateTriangleArea(int[] sideOne, int[] sideTwo, int[] sideThree)
    {
        return 0.5 * Math.Abs((sideOne[0] * (sideTwo[1] - sideThree[1])) + (sideTwo[0] * (sideThree[1] - sideOne[1])) + (sideThree[0] * (sideOne[1] - sideTwo[1])));
    }
}