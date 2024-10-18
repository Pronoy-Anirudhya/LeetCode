var l1 = new TreeNode(1);
var l2 = new TreeNode(2);
var l3 = new TreeNode(3);
var l4 = new TreeNode(4);
var l5 = new TreeNode(5);

l1.left = l2;
l1.right = l3;
l2.left = l4;
l2.right = l5;

Console.WriteLine(new Solution().DiameterOfBinaryTree(l1));
Console.ReadLine();

public class Solution
{
    private int Diameter = int.MinValue; //This here keeps updated for each node to store the maxDiameter for that particular node

    public int DiameterOfBinaryTree(TreeNode root)
    {
        DFSGetHeightFromCurrentNode(root);
        return Diameter;
    }

    //For every node, we calculate the maxDiameter and update the Global variable. Diameter is height of Left Subtree + height of Right Subtree. But the recursive function does not return the diameter. It actually returns the maximum height between left and right sub tree from the current tree. That's why we take max of left and right sub tree height and add 1 to it and return.
    private int DFSGetHeightFromCurrentNode(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftTreeDiameter = DFSGetHeightFromCurrentNode(node.left);
        int rightTreeDiameter = DFSGetHeightFromCurrentNode(node.right);

        int currentDiameter = leftTreeDiameter + rightTreeDiameter;
        Diameter = Math.Max(Diameter, currentDiameter);

        int heightFromCurrentNode = Math.Max(leftTreeDiameter, rightTreeDiameter) + 1;
        return heightFromCurrentNode;
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