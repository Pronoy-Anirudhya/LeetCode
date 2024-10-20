var root = new TreeNode(3);
var l9 = new TreeNode(9);
var l20 = new TreeNode(20);
var l15 = new TreeNode(15);
var l7 = new TreeNode(7);
var l8 = new TreeNode(9);

root.left = l9;
root.right = l20;
l20.left = l15;
l20.right = l7;
l7.left = l8;

Console.WriteLine(new Solution().IsBalanced(root));
Console.ReadLine();

public class Solution
{
    private bool IsBalancedTree = true;

    public bool IsBalanced(TreeNode root)
    {
        DFSGetSubTreeHeightsOfNode(root);
        return IsBalancedTree;
    }

    private int DFSGetSubTreeHeightsOfNode(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftSubTreeHeight = DFSGetSubTreeHeightsOfNode(node.left);
        int rightSubTreeHeight = DFSGetSubTreeHeightsOfNode(node.right);

        //If the difference of the LEFT & RIGHT Sub Tree is greater than 1, than it's not balanced.
        if (Math.Abs(leftSubTreeHeight - rightSubTreeHeight) > 1)
            IsBalancedTree = false;

        //We are adding one since we are returning up the value, so from this node, the caller in recursive function is one level above, so we have to add one. And for the height from this node downwards, we are taking the maximum height between LEFT & RIGHT Sub Tree.
        return Math.Max(leftSubTreeHeight, rightSubTreeHeight) + 1;
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