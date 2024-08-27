var leftTreeLeafRight = new TreeNode(1);
var leftTreeLeafLeft = new TreeNode(1);
var leftTreeParent = new TreeNode(1, leftTreeLeafLeft, leftTreeLeafRight);

var rightTreeLeafRight = new TreeNode(1);
var rightTreeLeafLeft = new TreeNode(1);
var rightTreeParent = new TreeNode(1, rightTreeLeafLeft, rightTreeLeafRight);

Console.WriteLine(new Solution().IsSameTree(leftTreeParent, rightTreeParent));
Console.ReadLine();

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
            return true;

        if (p == null || q == null)
            return false;

        if (p.val != q.val)
            return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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