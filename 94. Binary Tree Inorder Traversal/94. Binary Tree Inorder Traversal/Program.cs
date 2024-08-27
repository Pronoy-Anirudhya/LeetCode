var leafLeft2 = new TreeNode(3, null, null);
var leafRight1 = new TreeNode(2, leafLeft2, null);
var root = new TreeNode(1, null, leafRight1);
Console.WriteLine(new Solution().InorderTraversal(root));
Console.ReadLine();

public class Solution
{
    private IList<int> InorderTraversalNodes = new List<int>();

    public IList<int> InorderTraversal(TreeNode root)
    {
        var inorderTraversalStack = new Stack<TreeNode>();

        if (root == null)
            return InorderTraversalNodes;

        var current = root;

        while (current != null || inorderTraversalStack.Count != 0)
        {
            while (current != null)
            {
                inorderTraversalStack.Push(current);
                current = current.left;
            }

            var temp = inorderTraversalStack.Pop();
            current = temp.right;
            InorderTraversalNodes.Add(temp.val);
        }

        return InorderTraversalNodes; // Iterative approach
        //return InorderTraversalPrint(root); Recursive Approach
    }

    private IList<int> InorderTraversalPrint(TreeNode node)
    {
        if (node == null)
            return new List<int>();

        InorderTraversalPrint(node.left);
        InorderTraversalNodes.Add(node.val);
        InorderTraversalPrint(node.right);

        return InorderTraversalNodes;
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