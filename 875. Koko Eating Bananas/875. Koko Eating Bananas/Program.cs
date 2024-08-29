Console.WriteLine(new Solution().MinEatingSpeed([30, 11, 23, 4, 20], 5));
Console.ReadLine();

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var lowestEatingSpeed = 1;
        var highestEatingSpeed = piles.Max();
        var minimumEatingSpeed = highestEatingSpeed;

        while (lowestEatingSpeed <= highestEatingSpeed)
        {
            var currentEatingSpeed = lowestEatingSpeed + ((highestEatingSpeed - lowestEatingSpeed) / 2);
            long totalHoursRequiredForCurrentEatingSpeed = 0; //IMPORTANT to keep the variable type long instead of var. Otherwise runtime type will be int for var and then the accumulated value will overflow int capacity eventually producing wrong answer

            foreach (int pile in piles)
            {
                var hoursRequiredForThisPile = (int)Math.Ceiling((double)pile / currentEatingSpeed);
                totalHoursRequiredForCurrentEatingSpeed += hoursRequiredForThisPile;
            }

            if (totalHoursRequiredForCurrentEatingSpeed <= h)
            {
                minimumEatingSpeed = currentEatingSpeed;
                highestEatingSpeed = currentEatingSpeed - 1;
            }
            else
            {
                lowestEatingSpeed = currentEatingSpeed + 1;
            }
        }

        return minimumEatingSpeed;
    }
}