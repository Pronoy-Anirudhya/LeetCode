Console.WriteLine(new Solution().JudgeCircle("UD"));
Console.ReadLine();

public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int leftRightCount = 0, upDownCount = 0;

        // Loop through the moves and update the counts accordingly. 'L' and 'R' affect the leftRightCount, while 'U' and 'D' affect the upDownCount. At the end, if both counts are zero, it means the robot has returned to the origin. This works because 'L' and 'R' cancel each other out, as do 'U' and 'D'.
        foreach (char move in moves)
        {
            if ('L'.Equals(move))
                leftRightCount -= 1;
            else if ('R'.Equals(move))
                leftRightCount += 1;
            else if ('U'.Equals(move))
                upDownCount -= 1;
            else if ('D'.Equals(move))
                upDownCount += 1;
        }

        return leftRightCount == 0 && upDownCount == 0; // Check if both counts are zero, indicating the robot is back at the origin.
    }
}