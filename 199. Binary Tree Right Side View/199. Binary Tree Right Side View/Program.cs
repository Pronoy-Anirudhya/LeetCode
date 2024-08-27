var l2LeftNode = new TreeNode(5, new TreeNode(6));
var l2RightNode = new TreeNode(4);
var l1LeftNode = new TreeNode(2, null, l2LeftNode);
var l1RightNode = new TreeNode(3, null, l2RightNode);
var root = new TreeNode(1, l1LeftNode, l1RightNode);

Console.WriteLine(new Solution().RightSideView(root));
Console.ReadLine();

public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        var rightSideNodes = new List<int>();

        if (root == null)
            return rightSideNodes;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = new TreeNode();
            var queueSizeForThisLevel = queue.Count;

            while (queueSizeForThisLevel-- > 0)
            {
                node = queue.Dequeue();

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            rightSideNodes.Add(node.val);
        }

        return rightSideNodes;
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