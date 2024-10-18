var root = new TreeNode(-10);
var l9 = new TreeNode(9);
var l20 = new TreeNode(20);
var l15 = new TreeNode(15);
var l7 = new TreeNode(7);

root.left = l9;
root.right = l20;
l20.left = l15;
l20.right = l7;

Console.WriteLine(new Solution().MaxPathSum(root));
Console.ReadLine();

public class Solution
{
    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        DFSGetSum(root);
        return maxSum;
    }

    private int DFSGetSum(TreeNode node)
    {
        if (node == null)
            return 0;

        int sumOfLeftSubTree = DFSGetSum(node.left);
        int sumOfRightSubTree = DFSGetSum(node.right);

        //Since we want to maximize our sum, so we are discarding the -ve values if there are any for the left & right sub tree. It is required for cases such as [2, -1] where expected answer is 2 instead of 1.
        sumOfLeftSubTree = Math.Max(sumOfLeftSubTree, 0);
        sumOfRightSubTree = Math.Max(sumOfRightSubTree, 0);

        //Calculate the current sum up to this node by adding the node value and it's left & right sub tree values and update the maxSum accordingly
        int currentSumAtNode = node.val + sumOfLeftSubTree + sumOfRightSubTree;
        maxSum = Math.Max(maxSum, currentSumAtNode);

        //We would return the eligible sum that will contribute to the path sum that uses this node which means the sum with the maximum value will be sent up as the path sum between node + left & node + right sub tree
        int currentPathSum = node.val + Math.Max(sumOfLeftSubTree, sumOfRightSubTree);
        return currentPathSum;
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