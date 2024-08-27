Console.WriteLine(new Solution().DailyTemperatures([89, 62, 70, 58, 47, 47, 46, 76, 100, 70]));
Console.ReadLine();

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var answer = new int[temperatures.Length];

        if (temperatures.Length <= 1)
            return answer;

        var left = 0;
        var right = 1;

        while (left < temperatures.Length && right < temperatures.Length)
        {
            if (temperatures[right] > temperatures[left])
            {
                answer[left] = right - left;
                PrepareNumberOfDaysToGetAWarmerTemperature(temperatures, answer, left, right);
                left = right;
                right++;
            }
            else
                right++;
        }

        return answer;
    }

    private void PrepareNumberOfDaysToGetAWarmerTemperature(int[] temperatures, int[] answers, int leftIndex, int rightIndex)
    {
        var globalMaxTemperatureIndex = rightIndex;
        var currentMaxTemperature = temperatures[--rightIndex];
        var currentMaxTemperatureIndex = rightIndex;
        answers[rightIndex] = 1;

        while (--rightIndex > leftIndex)
        {
            if (temperatures[rightIndex + 1] > temperatures[rightIndex])
            {
                answers[rightIndex] = 1;
            }
            else if (currentMaxTemperature > temperatures[rightIndex])
            {
                answers[rightIndex] = currentMaxTemperatureIndex - rightIndex;
                currentMaxTemperature = temperatures[rightIndex];
                currentMaxTemperatureIndex = rightIndex;
            }
            else
            {
                answers[rightIndex] = globalMaxTemperatureIndex - rightIndex;
            }
        }
    }
}