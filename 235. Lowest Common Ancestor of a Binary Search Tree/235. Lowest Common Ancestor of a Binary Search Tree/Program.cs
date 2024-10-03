var root = new TreeNode(6);
var l2 = new TreeNode(2);
var l8 = new TreeNode(8);
root.left = l2;
root.right = l8;
var l0 = new TreeNode(0);
var l4 = new TreeNode(4);
l2.left = l0;
l2.right = l4;
var l3 = new TreeNode(3);
var l5 = new TreeNode(5);
l4.left = l3;
l4.right = l5;
var l7 = new TreeNode(7);
var l9 = new TreeNode(9);
l8.left = l7;
l8.right = l9;

Console.WriteLine(new Solution().LowestCommonAncestor(root, new TreeNode(2), new TreeNode(4)));
Console.ReadLine();

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        //Since BST'r parent node is ALWAYS GREATER than it's LEFT Child and SMALLER than it's RIGHT Child, we can leverage that knowledge to search in a efficient manner to get the LCA.
        //It's like binary search, if parent's value is greater than the both p's value & q's value then go left. If parent's value is smaller than the both p's value & q's value then go right. If parent's value is in between p & q's value then parent is the LCA!
        while (true)
        {
            if (root.val > p.val && root.val > q.val)
                root = root.left;
            else if (root.val < p.val && root.val < q.val)
                root = root.right;
            else
                return root;
        }
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)
    {
        val = x;
    }
}