Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null)
            return true;

        if (root1 == null || root2 == null)
            return false;

        Queue<TreeNode> bfsQueueTree1 = [], bfsQueueTree2 = [];
        bfsQueueTree1.Enqueue(root1);
        bfsQueueTree2.Enqueue(root2);

        //The idea here is to run two BFS on two trees and check if same parent in same level for two trees have same pair of child nodes or not. Since flipping would only change the side (left->right or right->left), so the order will remain intact
        while (bfsQueueTree1.Count > 0)
        {
            int currentLevelChildCountForTree1 = bfsQueueTree1.Count, currentLevelChildCountForTree2 = bfsQueueTree2.Count;

            if (currentLevelChildCountForTree1 != currentLevelChildCountForTree2)
                return false;

            Dictionary<int, HashSet<int>> currentLevelParentChildMap = [];

            while (currentLevelChildCountForTree1-- > 0)
            {
                TreeNode node1 = bfsQueueTree1.Dequeue();
                HashSet<int> childNodes = [];

                if (node1.left != null)
                {
                    childNodes.Add(node1.left.val);
                    bfsQueueTree1.Enqueue(node1.left);
                }

                if (node1.right != null)
                {
                    childNodes.Add(node1.right.val);
                    bfsQueueTree1.Enqueue(node1.right);
                }

                currentLevelParentChildMap.Add(node1.val, childNodes);
            }

            while (currentLevelChildCountForTree2-- > 0)
            {
                TreeNode node2 = bfsQueueTree2.Dequeue();

                if (!currentLevelParentChildMap.ContainsKey(node2.val))
                    return false;

                HashSet<int> currentLevelChildNodesOfTree1 = currentLevelParentChildMap[node2.val];

                if (node2.left != null)
                {
                    if (!currentLevelChildNodesOfTree1.Contains(node2.left.val))
                        return false;

                    bfsQueueTree2.Enqueue(node2.left);
                }

                if (node2.right != null)
                {
                    if (!currentLevelChildNodesOfTree1.Contains(node2.right.val))
                        return false;

                    bfsQueueTree2.Enqueue(node2.right);
                }
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