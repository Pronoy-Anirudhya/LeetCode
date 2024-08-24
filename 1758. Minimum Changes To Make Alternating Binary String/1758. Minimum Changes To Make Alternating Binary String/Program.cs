Console.WriteLine(new Solution().MinOperations("10010100"));
Console.ReadLine();

public class Solution
{
    public int MinOperations(string s)
    {
        var minimumOperationCountStartingWithZero = 0;
        var previousCharacter = '1';

        for (int i = 0; i < s.Length; i++)
        {
            var currentCharacter = s[i];

            if (previousCharacter != currentCharacter)
            {
                previousCharacter = currentCharacter;
            }
            else
            {
                previousCharacter = previousCharacter == '1' ? '0' : '1';
                minimumOperationCountStartingWithZero++;
            }
        }

        var minimumOperationCountStartingWithOne = s.Length - minimumOperationCountStartingWithZero;
        return Math.Min(minimumOperationCountStartingWithZero, minimumOperationCountStartingWithOne);
    }
}

//Since alternating sequence can be started with either 0 or 1, so if we can calculate the minimum count for one series (e.g. starting the sequence with 0) then we can get the other count by just subtracting the calculated count from the length of the string, which is the all possible ways of achieving the result.