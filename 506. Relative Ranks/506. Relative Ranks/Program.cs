Console.WriteLine(new Solution().FindRelativeRanks([10, 3, 8, 9, 4]));
Console.ReadLine();

public class Solution
{
    public string[] FindRelativeRanks(int[] score)
    {
        var rank = new string[score.Length];
        var indexDictionary = new Dictionary<int, int>();

        for (int i = 0; i < score.Length; i++)
            indexDictionary[score[i]] = i;

        Array.Sort(score);

        for (int i = 0; i < score.Length; i++)
        {
            var indexOfScore = indexDictionary[score[i]];

            if (i == score.Length - 1)
                rank[indexOfScore] = "Gold Medal";
            else if (i == score.Length - 2)
                rank[indexOfScore] = "Silver Medal";
            else if (i == score.Length - 3)
                rank[indexOfScore] = "Bronze Medal";
            else
                rank[indexOfScore] = (score.Length - i).ToString();
        }

        return rank;
    }
}