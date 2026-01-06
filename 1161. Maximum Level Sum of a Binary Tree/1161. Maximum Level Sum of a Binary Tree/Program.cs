//[1,7,0,7,-8,null,null]
TreeNode t37 = new(7);
TreeNode t3M8 = new(-8);
TreeNode t27 = new(7, t37, t3M8);
TreeNode t20 = new(0);
TreeNode root = new(1, t27, t20);
Console.WriteLine(new Solution().MaxLevelSum(root));
Console.ReadLine();

public class Solution
{
    public int MaxLevelSum(TreeNode root)
    {
        int maxLevel = -1, currentLevel = 1, maxLevelSum = int.MinValue;
        Queue<TreeNode> bfs = [];
        bfs.Enqueue(root);

        while (bfs.Count > 0)
        {
            int currentLevelChileCount = bfs.Count, currentLevelSum = 0;

            // Process all nodes at the current level. Current level nodes are the only nodes in the queue at this point. 
            while (currentLevelChileCount-- > 0)
            {
                TreeNode currentNode = bfs.Dequeue();
                currentLevelSum += currentNode.val; // Update the sum for the current level.

                // Enqueue child nodes of the current node for processing at the next level.
                if (currentNode.left != null)
                    bfs.Enqueue(currentNode.left);

                if (currentNode.right != null)
                    bfs.Enqueue(currentNode.right);
            }

            // Update max level sum and corresponding level if needed.
            if (currentLevelSum > maxLevelSum)
            {
                maxLevelSum = currentLevelSum;
                maxLevel = currentLevel;
            }

            currentLevel++;
        }

        return maxLevel;
    }
}

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}