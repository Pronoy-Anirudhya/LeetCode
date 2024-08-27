var m1 = new int[] { 2, 3 };
var m2 = new int[] { 1, 3 };
var m3 = new int[] { 5, 4 };
var m4 = new int[] { 6, 4 };
int[][] matches = new int[][] { m1, m2, m3, m4 };
Console.WriteLine(new Solution().FindWinners(matches));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        Dictionary<int, int> winners = new Dictionary<int, int>();
        Dictionary<int, int> losers = new Dictionary<int, int>(); ;

        foreach (var match in matches)
        {
            var winner = match[0];
            var loser = match[1];

            if (winners.ContainsKey(winner))
                winners[winner] += 1;
            else
                winners[winner] = 1;

            if (losers.ContainsKey(loser))
                losers[loser] += 1;
            else
                losers[loser] = 1;
        }

        var loserOutput = losers.Where(l => l.Value == -1).Select(l => l.Key).ToList();
        var winnerOutput = new List<int>();

        foreach (var winner in winners)
        {
            if (!losers.ContainsKey(winner.Key))
                winnerOutput.Add(winner.Key);
        }

        winnerOutput.Sort();
        loserOutput.Sort();
        var result = new List<IList<int>>() { winnerOutput, loserOutput };

        return result;
    }
}