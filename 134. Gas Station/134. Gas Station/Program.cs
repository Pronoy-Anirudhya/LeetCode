var gas = new int[] { 4, 5, 2, 6, 5, 3 };
var cost = new int[] { 3, 2, 7, 3, 2, 9 };
Console.WriteLine(new Solution().CanCompleteCircuit(gas, cost));
Console.ReadLine();

public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        //Brute-force solution
        //var completedGasStationIndexQueue = new Queue<int>();
        //var index = 0;
        //var fuel = 0;

        //while (true)
        //{
        //    if (index >= gas.Length)
        //        index = 0;

        //    fuel += gas[index] - cost[index];

        //    if (fuel >= 0)
        //    {
        //        completedGasStationIndexQueue.Enqueue(index);

        //        if (completedGasStationIndexQueue.Count == gas.Length)
        //            return completedGasStationIndexQueue.Dequeue();

        //        index++;
        //    }
        //    else
        //    {
        //        var previousStartingIndex = completedGasStationIndexQueue.Count != 0 ? completedGasStationIndexQueue.Dequeue() : index;
        //        fuel = 0;
        //        completedGasStationIndexQueue = new Queue<int>();

        //        if (previousStartingIndex < gas.Length - 1)
        //            index = ++previousStartingIndex;
        //        else
        //            break;
        //    }
        //}

        //Optimized one-pass solution
        var currentFuel = 0;
        var totalFuel = 0;
        var startingIndex = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            currentFuel += gas[i] - cost[i];
            totalFuel += gas[i] - cost[i];

            if (currentFuel < 0)
            {
                startingIndex = i + 1;
                currentFuel = 0;
            }
        }

        return totalFuel >= 0 ? startingIndex : -1;
    }
}