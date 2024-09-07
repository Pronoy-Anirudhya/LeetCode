var l3 = new ListNode(8);
var l2 = new ListNode(2, l3);
var head = new ListNode(4, l2);

var tl5 = new TreeNode(1);
var tr5 = new TreeNode(3);
var tr4 = new TreeNode(8, tl5, tr5);
var tl4 = new TreeNode(6);
var tl3 = new TreeNode(2, tl4, tr4);
var tr2 = new TreeNode(4, tl3);

var tll4 = new TreeNode(1);
var trr3 = new TreeNode(2, tll4);
var tll2 = new TreeNode(4, null, trr3);
var root = new TreeNode(1, tll2, tr2);

Console.WriteLine(new Solution().IsSubPath(head, root));
Console.ReadLine();

public class Solution
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        if (head == null || root == null)
            return false;

        if (DFS(head, root))
            return true;

        return IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }

    private bool DFS(ListNode node, TreeNode tree)
    {
        if (node == null)
            return true;

        if (tree == null || node.val != tree.val)
            return false;

        return DFS(node.next, tree.left) || DFS(node.next, tree.right);
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
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