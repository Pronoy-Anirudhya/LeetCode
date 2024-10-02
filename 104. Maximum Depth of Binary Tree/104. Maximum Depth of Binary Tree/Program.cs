var l5 = new TreeNode(5);
var l4 = new TreeNode(4);
var l3 = new TreeNode(3);
l3.left = l4;
l3.right = l5;
var l2 = new TreeNode(2);
var root = new TreeNode(1);
root.left = l2;
root.right = l3;

Console.WriteLine(new Solution().MaxDepth(root));
Console.ReadLine();

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        int maxDepth = 0;
        Queue<TreeNode> bfsQueue = [];
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            int currentQueueCount = bfsQueue.Count;

            while (currentQueueCount-- > 0)
            {
                TreeNode currentNode = bfsQueue.Dequeue();

                if (currentNode.left != null)
                    bfsQueue.Enqueue(currentNode.left);

                if (currentNode.right != null)
                    bfsQueue.Enqueue(currentNode.right);
            }

            maxDepth++;
        }

        return maxDepth;
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