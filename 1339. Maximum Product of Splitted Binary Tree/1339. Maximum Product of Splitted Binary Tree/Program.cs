Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    private const int mod = 1000000007;
    private long totalTreeSum = 0;
    private long maxProduct = 0;

    public int MaxProduct(TreeNode root)
    {
        DfsCalculateTotalTreeSum(root);
        DfsCalculateSubtreeSum(root);
        return (int)(maxProduct % mod);
    }

    // Calculate the total sum of all nodes in the tree.
    private void DfsCalculateTotalTreeSum(TreeNode node)
    {
        // Base case.
        if (node == null)
            return;

        // The logic here is to perform a DFS traversal and accumulate the sum recursively.
        totalTreeSum += node.val;
        DfsCalculateTotalTreeSum(node.left);
        DfsCalculateTotalTreeSum(node.right);
    }

    // Calculate the subtree sums and update the maximum product. The product is calculated as: subtreeSum * (totalTreeSum - subtreeSum) which represents the product of the sums of the two resulting trees after a split. The maximum product is updated whenever a higher product is found.
    private long DfsCalculateSubtreeSum(TreeNode node)
    {
        if (node == null)
            return 0;

        // Post-order traversal to calculate subtree sums. Then calculate the product for each subtree and update the maximum product.
        long leftSum = DfsCalculateSubtreeSum(node.left);
        long rightSum = DfsCalculateSubtreeSum(node.right);
        long currentSubTreeSum = node.val + leftSum + rightSum; // Current subtree sum.
        long currentSubTreeProduct = currentSubTreeSum * (totalTreeSum - currentSubTreeSum);
        maxProduct = Math.Max(maxProduct, currentSubTreeProduct); // Update max product if current is greater.

        return currentSubTreeSum; // Return the subtree sum to the parent call. This is essential for calculating the sums of larger subtrees. Time Complexity: O(N) where N is the number of nodes in the tree, as we visit each node exactly once. Space Complexity: O(H) where H is the height of the tree, due to the recursion stack.
    }
}

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}