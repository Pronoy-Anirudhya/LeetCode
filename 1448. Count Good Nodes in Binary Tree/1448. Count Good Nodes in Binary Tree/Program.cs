var root = new TreeNode(3);
var l1 = new TreeNode(1);
var l4 = new TreeNode(4);
root.left = l1;
root.right = l4;
var l3 = new TreeNode(3);
l1.left = l3;
var lr1 = new TreeNode(1);
var lr5 = new TreeNode(5);
l4.left = lr1;
l4.right = lr5;

Console.WriteLine(new Solution().GoodNodes(root));
Console.ReadLine();

public class Solution
{
    public int GoodNodes(TreeNode root)
    {
        int goodNodes = 0, maxTillNow = int.MinValue;
        Stack<(TreeNode node, int maxTillNow)> dfsStack = [];

        while (root != null || dfsStack.Count > 0)
        {
            while (root != null)
            {
                if (root.val >= maxTillNow)
                {
                    maxTillNow = root.val;
                    goodNodes++;
                }
                
                dfsStack.Push((root, maxTillNow));
                root = root.left;
            }

            (root, maxTillNow) = dfsStack.Pop();
            root = root.right;
        }

        return goodNodes;
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