Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBSTSubtree(root, double.NegativeInfinity, double.PositiveInfinity);
    }

    private bool IsValidBSTSubtree(TreeNode node, double floorValue, double ceilingValue)
    {
        if (node == null)
            return true;

        if (!(node.val > floorValue && node.val < ceilingValue))
            return false;

        return IsValidBSTSubtree(node.left, floorValue, node.val) && IsValidBSTSubtree(node.right, node.val, ceilingValue);
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