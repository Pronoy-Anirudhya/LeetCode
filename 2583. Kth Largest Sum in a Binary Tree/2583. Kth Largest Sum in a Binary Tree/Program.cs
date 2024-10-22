Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        PriorityQueue<long, long> minHeap = new();
        Queue<TreeNode> bfsQueue = [];
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            int currentLevelChildCount = bfsQueue.Count;
            long currentLevelSum = 0;

            while (currentLevelChildCount-- > 0)
            {
                TreeNode node = bfsQueue.Dequeue();
                currentLevelSum += node.val;

                if (node.left != null)
                    bfsQueue.Enqueue(node.left);

                if (node.right != null)
                    bfsQueue.Enqueue(node.right);
            }

            minHeap.Enqueue(currentLevelSum, currentLevelSum);

            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        return minHeap.Count == k ? minHeap.Dequeue() : -1;
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