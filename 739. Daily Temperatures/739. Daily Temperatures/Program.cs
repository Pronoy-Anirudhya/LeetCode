Console.WriteLine(new Solution().DailyTemperatures([89, 62, 70, 58, 47, 47, 46, 76, 100, 70]));
Console.ReadLine();

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var answer = new int[temperatures.Length];

        if (temperatures.Length <= 1)
            return answer;

        var monoDecreasingStack = new Stack<int>();

        for (int currentTemperatureIndex = temperatures.Length - 1; currentTemperatureIndex >= 0; currentTemperatureIndex--)
        {
            var currentTemperature = temperatures[currentTemperatureIndex];

            if (monoDecreasingStack.Count == 0)
            {
                answer[currentTemperatureIndex] = 0;
                monoDecreasingStack.Push(currentTemperatureIndex);
            }
            else
            {
                var currentMaxTemperature = temperatures[monoDecreasingStack.Peek()];

                if (currentTemperature < currentMaxTemperature)
                {
                    answer[currentTemperatureIndex] = monoDecreasingStack.Peek() - currentTemperatureIndex;
                    monoDecreasingStack.Push(currentTemperatureIndex);
                }
                else
                {
                    while (monoDecreasingStack.Count > 0 && currentTemperature >= temperatures[monoDecreasingStack.Peek()])
                        monoDecreasingStack.Pop();

                    answer[currentTemperatureIndex] = monoDecreasingStack.Count > 0 ? monoDecreasingStack.Peek() - currentTemperatureIndex : 0;
                    monoDecreasingStack.Push(currentTemperatureIndex);
                }
            }
        }

        return answer;
    }
}