Console.WriteLine(String.Join(",", new Solution().Generate(5)));

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            var row = new List<int>();
            row.Add(1);

            for (int j = 1; j <i; j++)
                row.Add(result[i - 1][j - 1] + result[i - 1][j]);

            if (i != 0)
                row.Add(1);

            result.Add(row);
        }

        return result;
    }
}