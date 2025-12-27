Console.WriteLine(new Solution().BestClosingTime("YN"));
Console.ReadLine();

public class Solution
{
    public int BestClosingTime(string customers)
    {
        int bestClosingTime = 0, minimumPenalty = 0, currentPenalty = 0; // Initialize variables to track the best closing time, minimum penalty, and current penalty. Current penalty starts at 0 because closing at hour 0 incurs no penalty.

        for (int index = 0; index < customers.Length; index++)
        {
            char currentCharacter = customers[index];

            // If the current character is 'Y', we reduce the penalty by 1 (since closing after this hour avoids a penalty). Otherwise, we increase the penalty by 1 (since closing after this hour incurs a penalty).
            if ('Y'.Equals(currentCharacter))
                currentPenalty--;
            else
                currentPenalty++;

            // Update the best closing time and minimum penalty if the current penalty is lower than the minimum penalty found so far.
            if (currentPenalty < minimumPenalty)
            {
                bestClosingTime = index + 1; // +1 because closing time is after the current hour
                minimumPenalty = currentPenalty;
            }
        }

        return bestClosingTime;
    }
}