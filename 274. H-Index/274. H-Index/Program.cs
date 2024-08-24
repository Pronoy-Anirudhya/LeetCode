Console.WriteLine(new Solution().HIndex(new int[] { 3, 0, 6, 1, 5 }));
Console.ReadLine();

public class Solution
{
    public int HIndex(int[] citations)
    {
        var hIndex = 0;
        var paperPublished = citations.Length;

        //Brute-force O(n2) approach:
        /*for (int currentHIndex = 1; currentHIndex <= paperPublished; currentHIndex++)
        {
            var citedPaperCount = 0;

            for (int i = 0; i < paperPublished; i++)
            {
                if (citations[i] >= currentHIndex)
                    citedPaperCount++;

                if (citedPaperCount == currentHIndex)
                {
                    hIndex = Math.Max(hIndex, currentHIndex);
                    break;
                }
            }
        }*/

        //Optimal Counting Sort O(n) approach:
        var citedPaperCount = new int[paperPublished + 1];

        for (int i = 0; i < paperPublished; i++)
        {
            if (citations[i] >= citedPaperCount.Length - 1)
                citedPaperCount[citedPaperCount.Length - 1]++;
            else
                citedPaperCount[citations[i]]++;
        }

        var citationCount = 0;

        for (int currentHIndex = citedPaperCount.Length - 1; currentHIndex > 0; currentHIndex--)
        {
            citationCount += citedPaperCount[currentHIndex];

            if (citationCount >= currentHIndex)
                return currentHIndex;
        }

        return hIndex;
    }
}