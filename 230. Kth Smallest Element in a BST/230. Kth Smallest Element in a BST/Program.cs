var l6 = new TreeNode(6);
var root = new TreeNode(5);
var l4 = new TreeNode(4);
var l3 = new TreeNode(3);
var l2 = new TreeNode(2);
var l1 = new TreeNode(1);

root.right = l6;
l2.left = l1;
l3.left = l2;
l3.right = l4;
root.left = l3;

Console.WriteLine(new Solution().KthSmallest(root, 3));
Console.ReadLine();

public class Solution
{
    /*O(n) iterative DFS solution. Here we are going down the left SUBTREE and ushing the nodes value along the way. Then when we finally reach the bottom, we are poppinh a node and decrementing K by 1 since we have found THE smallest value in the BST. Now, if k == 0 then we return and be done with it or else we go right from that node and repeat the whole process of going down the left SUBTREE for that RIGHT node untill it gets to the bottom and repeat untill node is null or the stack is empty. Since it is inorder traversal, so the order in which the nodes will be popped from the stack will be incremental from the smallest to the largest values e.g. 1, 2, 3,...6.*/
    public int KthSmallest(TreeNode root, int k)
    {
        Stack<TreeNode> stack = [];

        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();

            if (--k == 0)
                return root.val;

            root = root.right;
        }

        return -1;
    }

    //Inorder (right to left) Heap Solution: O(NLogK)
    /*public readonly PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    
    public int KthSmallest(TreeNode root, int k)
    {
        //Inorder (right to left) Heap Solution: O(NLogK)
        maxHeap.EnsureCapacity(k);
        InorderBSTTraversal(root, k);
        return maxHeap.Dequeue();
    }

    private void InorderBSTTraversal(TreeNode node, int k)
    {
        if (node == null)
            return;

        InorderBSTTraversal(node.right, k);

        if (maxHeap.Count >= k)
            maxHeap.Dequeue();

        maxHeap.Enqueue(node.val, node.val);
        InorderBSTTraversal(node.left, k);
    }*/
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