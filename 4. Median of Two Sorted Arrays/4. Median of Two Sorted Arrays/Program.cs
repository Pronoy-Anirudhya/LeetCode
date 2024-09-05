Console.WriteLine(new Solution().FindMedianSortedArrays([1, 2], [3, 4]));
Console.ReadLine();

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var mergedArrayLength = nums1.Length + nums2.Length;

        if (mergedArrayLength == 0)
            return 0;

        double median = 0;
        var isEvenLength = mergedArrayLength % 2 == 0;
        var mergedArrayIndex = 0;
        var leftArrayIndex = 0;
        var rightArrayIndex = 0;
        var medianIndex = mergedArrayLength / 2;

        while (mergedArrayIndex <= medianIndex)
        {
            int currentNumber;
            var isLeftArrayValid = nums1.Length > 0 && leftArrayIndex < nums1.Length;
            var leftArrayNumber = isLeftArrayValid ? nums1[leftArrayIndex] : 0;
            var isRightArrayValid = nums2.Length > 0 && rightArrayIndex < nums2.Length;
            var rightArrayNumber = isRightArrayValid ? nums2[rightArrayIndex] : 0;

            if (!isLeftArrayValid && !isRightArrayValid)
                return 0;

            if (isLeftArrayValid && isRightArrayValid)
            {
                if (leftArrayNumber < rightArrayNumber)
                {
                    currentNumber = nums1[leftArrayIndex];
                    leftArrayIndex++;
                }
                else
                {
                    currentNumber = nums2[rightArrayIndex];
                    rightArrayIndex++;
                }
            }
            else if (isLeftArrayValid)
            {
                currentNumber = leftArrayNumber;
                leftArrayIndex++;
            }
            else
            {
                currentNumber = nums2[rightArrayIndex];
                rightArrayIndex++;
            }

            if (isEvenLength && mergedArrayIndex == medianIndex - 1 || mergedArrayIndex == medianIndex)
                median += currentNumber;

            mergedArrayIndex++;
        }

        return isEvenLength ? (double)median / 2 : median;
    }
}