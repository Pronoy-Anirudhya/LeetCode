Console.WriteLine(new Solution().FindCircleNum([[1, 0, 0], [0, 1, 0], [0, 0, 1]]));
Console.ReadLine();

public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length, province = 0;
        bool[] visited = new bool[n];
        Queue<int> bfs = [];

        /*
         * Intuition: I will use BFS to traverse the graph and count the number of connected components (provinces). Just check whether it has already been visited or not. If not, add it to the queue and mark it as visited. Then, check its neighbors and add them to the queue if they are connected and not visited yet. Continue until all cities in the current province are visited. Finally, increment the province count for each BFS traversal that starts from an unvisited city.
        */
        for (int city = 0; city < n; city++)
        {
            if (!visited[city])
            {
                bfs.Enqueue(city);

                while (bfs.Count > 0)
                {
                    int currentCity = bfs.Dequeue();
                    visited[currentCity] = true;

                    for (int neighbor = 0; neighbor < n; neighbor++)
                    {
                        if (currentCity != neighbor && !visited[neighbor] && isConnected[currentCity][neighbor] == 1)
                        {
                            visited[neighbor] = true;
                            bfs.Enqueue(neighbor);
                        }
                    }
                }

                province++;
            }
        }

        return province;
    }
}