var leafLeft2 = new TreeNode(3, null, null);
var leafRight1 = new TreeNode(2, leafLeft2, null);
var root = new TreeNode(1, null, leafRight1);
Console.WriteLine(new Solution().PostorderTraversal(root));
Console.ReadLine();

public class Solution
{
    private List<int> PostorderTraversalNodes = new List<int>();

    public IList<int> PostorderTraversal(TreeNode root)
    {
        PostorderTraversalNodePrint(root);
        return PostorderTraversalNodes;
    }

    private void PostorderTraversalNodePrint(TreeNode node)
    {
        if (node == null)
            return;

        PostorderTraversalNodePrint(node.left);
        PostorderTraversalNodePrint(node.right);

        PostorderTraversalNodes.Add(node.val);
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