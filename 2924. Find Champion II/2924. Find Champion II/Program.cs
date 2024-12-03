Console.WriteLine(new Solution().FindChampion(3, [[0, 1], [1, 2]]));
Console.ReadLine();

public class Solution
{
    public int FindChampion(int n, int[][] edges)
    {
        int champion = -1;
        int[] inwardEdgeCount = new int[n];

        for (int index = 0; index < edges.Length; index++)
            inwardEdgeCount[edges[index][1]]++;

        for (int team = 0; team < inwardEdgeCount.Length; team++)
        {
            if (inwardEdgeCount[team] == 0)
            {
                if (champion == -1)
                    champion = team;
                else
                    return -1;
            }
        }

        return champion;
    }
}