var root = new TreeNode(3);
var subRoot = new TreeNode(4);
var l4 = new TreeNode(4);
var l5 = new TreeNode(5);
var l1 = new TreeNode(1);
var l2 = new TreeNode(2);

root.left = subRoot;
root.right = l5;
subRoot.left = l1;
subRoot.right = l2;

l4.left = l1;
l4.right = new(6);


Console.WriteLine(new Solution().IsSubtree(root, l4));
Console.ReadLine();

public class Solution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        Queue<TreeNode> bfsQueue = [];
        bfsQueue.Enqueue(root);

        //Since from any node of root can a subRoot start, so instead of recursive approach, we do a BFS iterative traversal for each root node and check whether the node value is equal to subRoot's value. If yes, then we start checking whether those two are same tree and if it is then return immediately. Or else we move forward until we meet another root node value tha's equal to subRoot node value. At the end, we return false since from no node we found the subRoot tree.
        while (bfsQueue.Count > 0)
        {
            int currentNodeCount = bfsQueue.Count;

            while (currentNodeCount-- > 0)
            {
                TreeNode node = bfsQueue.Dequeue();

                if (node.val == subRoot.val)
                {
                    bool isSameTree = IsSameTree(node, subRoot);

                    if (isSameTree)
                        return true;
                }

                if (node.left != null)
                    bfsQueue.Enqueue(node.left);
                
                if (node.right != null)
                    bfsQueue.Enqueue(node.right);
            }
        }

        return false;
    }

    private bool IsSameTree(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null)
            return true;

        if (node1 == null || node2 == null)
            return false;

        if (node1.val != node2.val)
            return false;

        return IsSameTree(node1.left, node2.left) && IsSameTree (node1.right, node2.right);
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