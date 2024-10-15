Console.WriteLine(new Solution().MinimumSteps("100"));
Console.ReadLine();

public class Solution
{
    public long MinimumSteps(string s)
    {
        long steps = 0;
        int left = 0;
        var characters = s.ToCharArray();
        left = ShiftLeftPointerTillItsOne(left, characters);

        for (int right = left + 1; right < characters.Length; right++)
        {
            //If the RIGHT character is ZERO, it means we now have to swap it with the leftmost ONE. Our LEFT pointer always points to the LEFTMOST one, so we just swap values for LEFT & RIGHT characters. Or else RIGHT character is ONE and we don't need to do anything, just keep going till we find a ZERO that needs to be swapped.
            if (characters[right] == '0')
            {
                characters[left] = '0';
                characters[right] = '1';
                steps += right - left;
                left = ShiftLeftPointerTillItsOne(left, characters);
            }
        }

        return steps;
    }

    //Since we always want to shift ONE to the right, so we would always want our LEFT pointer to be at a index where it is actually at the LEFTMOST ONE so that we can swap the RIGHT zeros with left pointer.
    private static int ShiftLeftPointerTillItsOne(int left, char[] characters)
    {
        while (left < characters.Length && characters[left] == '0')
            left++;

        return left;
    }
}