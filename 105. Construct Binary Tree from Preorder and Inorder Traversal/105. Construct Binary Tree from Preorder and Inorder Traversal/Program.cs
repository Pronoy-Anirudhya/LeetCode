Console.WriteLine(new Solution().BuildTree([3, 9], [3, 9]));
Console.ReadLine();

public class Solution
{
    private readonly int VISITED_INORDER_VALUE = 3001;//Once we visit a node in Inorder array, we would mark that index with this value so that we know it has already been visited
    private int PreorderIndex = 0;
    private Dictionary<int, int> InorderMap = [];//KEY: Node value, VALUE: Index of that node value in inorder array

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        for (int index = 0; index < inorder.Length; index++)
        {
            if (!InorderMap.TryAdd(inorder[index], index))
                InorderMap[inorder[index]] = index;
        }

        return DFSBuildTree(preorder, inorder, -1, true, true); ;
    }

    private TreeNode DFSBuildTree(int[] preorder, int[] inorder, int inorderRootIndex, bool isRootNode, bool isLeftSubTree)
    {
        //Checks whether we are trying to go left/right and the left/right of inorderRootIndex is inbound and not visited
        bool isLeftSubTreeUnavailable = isLeftSubTree && (inorderRootIndex - 1 < 0 || inorder[inorderRootIndex - 1] == VISITED_INORDER_VALUE);
        bool isRightSubTreeUnavailable = !isLeftSubTree && (inorderRootIndex + 1 >= inorder.Length || inorder[inorderRootIndex + 1] == VISITED_INORDER_VALUE);

        //For root node, we skip this validation since root must be created
        if (!isRootNode && (isLeftSubTreeUnavailable || isRightSubTreeUnavailable))
            return null;

        //The idea here is: The first value in Preorder will always be ROOT. Now we searc for that root node's value in Inorder array and pass it in the recursive function. Logic is: Left of the the inorder root index will be the current node's LEFT SUB TREE and Right of thr inorder root index will be current node's RIGHT SUB TREE. We do this recursively untill we hit the base case.
        TreeNode node = new(preorder[PreorderIndex]);
        int nextInorderRootIndex = InorderMap[preorder[PreorderIndex]];
        inorder[nextInorderRootIndex] = VISITED_INORDER_VALUE;
        PreorderIndex++;

        node.left = DFSBuildTree(preorder, inorder, nextInorderRootIndex, false, true);
        node.right = DFSBuildTree(preorder, inorder, nextInorderRootIndex, false, false);

        return node;
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