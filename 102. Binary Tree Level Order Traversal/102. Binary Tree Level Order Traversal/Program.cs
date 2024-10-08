Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return [];

        List<IList<int>> nodes = [];
        Queue<TreeNode> bfsQueue = [];
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            int nodeCountInQueue = bfsQueue.Count;
            List<int> nodesInCurrentLevel = [];

            while (nodeCountInQueue-- > 0)
            {
                TreeNode node = bfsQueue.Dequeue();
                nodesInCurrentLevel.Add(node.val);

                if (node.left != null)
                    bfsQueue.Enqueue(node.left);

                if (node.right != null)
                    bfsQueue.Enqueue(node.right);
            }

            nodes.Add(nodesInCurrentLevel);
        }

        return nodes;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}