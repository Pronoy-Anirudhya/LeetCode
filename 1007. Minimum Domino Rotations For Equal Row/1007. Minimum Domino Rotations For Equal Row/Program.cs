Console.WriteLine(new Solution().MinDominoRotations([1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 1, 1, 1, 1, 1, 1]));
Console.ReadLine();

public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        int minimumRotation = int.MaxValue, dominoLength = tops.Length;
        int[] numberCountOfDomino = new int[7], topNumberCount = new int[7], bottomNumberCount = new int[7];

        /*
         * Intuition: There can only be 6 numbers from 1 through 6. So, for any number from 1 through 6 to be on either sides, the total count of that number has to be equal to the length of the domino array. For example: [2, 2] and [1, 2] -> Here for 0-index of the 2 length domino, we increment count for both 1 and 2 in the numberCountOfDomino array. But for 1-index, since both top and bottom have same values, we only increment 2 once. So now the numberCountOfDomino array has [1, 2]. 2 has count 2 which is equal to the domino length.
        */
        for (int index = 0; index < dominoLength; index++)
        {
            int topNumber = tops[index], bottomNumber = bottoms[index];
            topNumberCount[topNumber]++;
            bottomNumberCount[bottomNumber]++;

            //Since same number in each side, increment just one number.
            if (topNumber == bottomNumber)
            {
                numberCountOfDomino[topNumber]++;
            }
            //Increment both numbers since we have different numbers on each side.
            else
            {
                numberCountOfDomino[topNumber]++;
                numberCountOfDomino[bottomNumber]++;
            }
        }

        for (int index = 1; index < numberCountOfDomino.Length; index ++)
        {
            //According to the algorith we devised, if for any number, the count is not equal to the length of the domino we have, that means that particular number can't be on all the indexes on either side. So we skip and continue to the next number.
            if (numberCountOfDomino[index] != dominoLength)
                continue;

            //We have kpet the count of occurrences of a number in both top and bottom array. To get the minimum roration, we have to subtract the MAXIMUM between those two from the length of domino. For example: [2, 2], [1, 2] -> topNumberCount[1: 0, 2: 2], bottomNumberCount[1: 1, 2: 1]. So dominoLength: 2 - MAX(2, 1) = 2 - 2 = 0
            int currentMinimumRotation = dominoLength - Math.Max(topNumberCount[index], bottomNumberCount[index]);
            minimumRotation = Math.Min(minimumRotation, currentMinimumRotation);
        }

        return minimumRotation == int.MaxValue ? -1 : minimumRotation;
    }
}