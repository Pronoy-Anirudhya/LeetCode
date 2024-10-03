var l3 = new TreeNode(3);
var l2 = new TreeNode(2);
var p = new TreeNode(1)
{
    left = l2,
    right = l3
};

var r3 = new TreeNode(3);
var r2 = new TreeNode(2);
var q = new TreeNode(1)
{
    left = r2,
    right = r3
};

Console.WriteLine(new Solution().IsSameTree(p, q));
Console.ReadLine();

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        //Recursive Solution
        /*if (p == null && q == null)
            return true;

        if (p == null || q == null)
            return false;

        if (p.val != q.val)
            return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);*/

        //BFS Solution
        if (p == null && q == null)
            return true;

        if (p == null || q == null)
            return false;

        Queue<(TreeNode pNode, TreeNode qNode)> bfsQueue = [];
        bfsQueue.Enqueue((p, q));

        while (bfsQueue.Count > 0)
        {
            int bfsQueueCount = bfsQueue.Count;

            while (bfsQueueCount-- > 0)
            {
                TreeNode pNode = bfsQueue.Peek().pNode;
                TreeNode qNode = bfsQueue.Peek().qNode;
                bfsQueue.Dequeue();

                if (pNode == null && qNode == null)
                    continue;

                if (pNode == null || qNode == null)
                    return false;

                if (pNode.val != qNode.val)
                    return false;

                bfsQueue.Enqueue((pNode.left, qNode.left));
                bfsQueue.Enqueue((pNode.right, qNode.right));
            }
        }

        return true;
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