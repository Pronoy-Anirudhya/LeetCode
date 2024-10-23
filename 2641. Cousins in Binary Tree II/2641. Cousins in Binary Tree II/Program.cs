Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        int currentLevelSum = 0;
        Dictionary<TreeNode, int> parentWiseChildValueSum = [];
        Queue<(TreeNode parent, TreeNode child)> bfsQqueue = [];
        bfsQqueue.Enqueue((null, root));

        while (bfsQqueue.Count > 0)
        {
            int currentLevelChildCount = bfsQqueue.Count, nextLevelSum = 0;

            while (currentLevelChildCount-- > 0)
            {
                int currentParentChildValueSum = 0;
                (TreeNode parent, TreeNode child) = bfsQqueue.Dequeue();

                if (parent != null)
                {
                    int childValueSum = parentWiseChildValueSum[parent];
                    child.val = currentLevelSum - childValueSum;
                }
                else
                    child.val = 0;

                if (child.left != null)
                {
                    currentParentChildValueSum += child.left.val;
                    nextLevelSum += child.left.val;
                    bfsQqueue.Enqueue((child, child.left));
                }

                if (child.right != null)
                {
                    currentParentChildValueSum += child.right.val;
                    nextLevelSum += child.right.val;
                    bfsQqueue.Enqueue((child, child.right));
                }

                parentWiseChildValueSum.Add(child, currentParentChildValueSum);
            }

            currentLevelSum = nextLevelSum; //We calculated the current parent's all the child value sum and assigned it to currentLevelSum that will be used in the next level to determine the cousin sum
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