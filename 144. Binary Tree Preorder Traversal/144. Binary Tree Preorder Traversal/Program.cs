var leafLeft2 = new TreeNode(3, null, null);
var leafRight1 = new TreeNode(2, leafLeft2, null);
var root = new TreeNode(1, null, leafRight1);
Console.WriteLine(new Solution().PreorderTraversal(root));
Console.ReadLine();

public class Solution
{
    private List<int> PreorderTraversalNodes = new List<int>();

    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
            return PreorderTraversalNodes;

        var preorderTraversalNodeStack = new Stack<TreeNode>();
        preorderTraversalNodeStack.Push(root);

        while (preorderTraversalNodeStack.Count > 0)
        {
            var current = preorderTraversalNodeStack.Peek();
            preorderTraversalNodeStack.Pop();
            PreorderTraversalNodes.Add(current.val);

            if (current.right != null)
                preorderTraversalNodeStack.Push(current.right);

            if (current.left != null)
                preorderTraversalNodeStack.Push(current.left);
        }

        //PreorderTraversalNodePrint(root); Recursive approach
        return PreorderTraversalNodes; // Iterative approach
    }

    private void PreorderTraversalNodePrint(TreeNode node)
    {
        if (node == null)
            return;

        PreorderTraversalNodes.Add(node.val);
        PreorderTraversalNodePrint(node.left);
        PreorderTraversalNodePrint(node.right);
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