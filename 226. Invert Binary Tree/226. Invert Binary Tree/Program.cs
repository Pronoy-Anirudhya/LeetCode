Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return root;

        //Recursive solution
        /*TreeNode leftChild = root.left, rightChild = root.right;
        root.left = InvertTree(rightChild);
        root.right = InvertTree(leftChild);*/

        Queue<TreeNode> bfsQueue = [];
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            var node = bfsQueue.Dequeue();
            TreeNode leftChild = node.left, rightChild = node.right;

            if (node.left != null)
                bfsQueue.Enqueue(leftChild);

            if (node.right != null)
                bfsQueue.Enqueue(rightChild);

            node.left = rightChild;
            node.right = leftChild;
        }

        return root;
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