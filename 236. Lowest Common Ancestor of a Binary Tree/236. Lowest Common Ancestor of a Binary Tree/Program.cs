var root = new TreeNode(3);
var l0 = new TreeNode(0);
var l1 = new TreeNode(1);
var l2 = new TreeNode(2);
var l3 = new TreeNode(3);
var l4 = new TreeNode(4);
var l5 = new TreeNode(5);
var l6 = new TreeNode(6);
var l7 = new TreeNode(7);
var l8 = new TreeNode(8);

root.left = l5;
root.right = l1;
l5.left = l6;
l5.right = l2;
l2.left = l7;
l2.right = l4;
l1.left = l0;
l1.right = l8;

Console.WriteLine(new Solution().LowestCommonAncestor(root, l5, l4));
Console.ReadLine();

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
            return root;

        Queue<TreeNode> bfsQueue = [];
        Dictionary<TreeNode, TreeNode> parentMap = []; //KEY: Child, VALUE: Parent
        HashSet<TreeNode> ancestors = [];

        bfsQueue.Enqueue(root);
        parentMap.Add(root, null); //Add root in the map with parent as NULL since root doesn't have any parent

        //Build the parent map for the entire Tree to be used later to build the P's ancestor set -> O(n) space
        while (bfsQueue.Count > 0)
        {
            int currentNodeCount = bfsQueue.Count;

            while (currentNodeCount-- > 0)
            {
                TreeNode node = bfsQueue.Dequeue();

                if (node.left != null)
                {
                    parentMap.Add(node.left, node);
                    bfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    parentMap.Add(node.right, node);
                    bfsQueue.Enqueue(node.right);
                }
            }
        }

        //Build the ancestor set of P. So all the possible ancestor will be in this set. If Q has one of the parent as it's ancestor then we can say that's the LCA
        while (p != null)
        {
            ancestors.Add(p);
            p = parentMap[p];
        }

        //From bottom up, we are getting each parent of Q and checking whether or not it is present in P's ancestor set. The common parent of P & Q is the LCA 
        while (!ancestors.Contains(q))
            q = parentMap[q];

        return q;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)
    {
        val = x;
    }
}