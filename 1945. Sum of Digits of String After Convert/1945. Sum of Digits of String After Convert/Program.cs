Console.WriteLine(new Solution().GetLucky("iiii", 1));
Console.ReadLine();

public class Solution
{
    public int GetLucky(string s, int k)
    {
        int transformedSum = 0;

        //Here we are converting as well as transforming by summing the converted digits simultaneously. So after this step, we only need to do the transformation up to (k-1) times
        for (int i = 0; i < s.Length; i++)
        {
            int positionOfCurrentCharacter = s[i] - 'a' + 1;

            while (positionOfCurrentCharacter > 0)
            {
                transformedSum += (positionOfCurrentCharacter % 10);
                positionOfCurrentCharacter /= 10;
            }
        }

        //Since we have to do it (k-1) times, that's why (--k > 0) instead of (k-- > 0)
        while (--k > 0)
        {
            int currentSum = 0;

            while (transformedSum > 0)
            {
                currentSum += (transformedSum % 10);
                transformedSum /= 10;
            }

            transformedSum = currentSum;
        }

        return transformedSum;
    }
}