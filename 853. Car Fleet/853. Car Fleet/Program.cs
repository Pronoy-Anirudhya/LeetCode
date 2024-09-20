Console.WriteLine(new Solution().CarFleet(10, [0, 2, 4], [4, 2, 1]));
Console.ReadLine();

public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        int carFleet = 0, numberOfCars = position.Length;
        var timeRequiredToReachTarget = new float[numberOfCars];
        var cars = new (int position, int speed)[numberOfCars];

        for (int index = 0; index < numberOfCars; index++)
            cars[index] = (position[index], speed[index]);

        //After sorting, the rightmost car will be the closest to target initially. And we want to know if any car behind it can catch-up before it can reach the target. It translates logically like this: If the closest car's required time is greater than the car behind, then the car behind will catch up to it, otherwise car behind can never catch up.
        Array.Sort(cars);

        for (int index = numberOfCars - 1; index >= 0; index--)
        {
            int remainingDistanceToReachTarget = target - cars[index].position;
            timeRequiredToReachTarget[index] = (float)remainingDistanceToReachTarget / cars[index].speed;

            //If it's not the rightmost car (closest to target), we will check whether it can catch up with the car ahead. If yes, then we will assign the slowest cars (the car ahead) time to it. Else, it means we have formed a car fleet so increment the car fleet counter.
            if (index < numberOfCars - 1 && timeRequiredToReachTarget[index] <= timeRequiredToReachTarget[index + 1])
                timeRequiredToReachTarget[index] = timeRequiredToReachTarget[index + 1];
            else
                carFleet++;
        }

        return carFleet;
    }
}