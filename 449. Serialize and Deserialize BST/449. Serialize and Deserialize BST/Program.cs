var l1 = new TreeNode(1);
var l2 = new TreeNode(2);
var l3 = new TreeNode(3);

l1.left = l2;
l1.right = l3;

var data = new Codec().serialize(l1);
Console.WriteLine(data);
Console.WriteLine(new Codec().deserialize(data));
Console.ReadLine();

//TODO: I have written the exact same solution I used to serialzie/deserialzie Binary Tree. But here in the deserialize part, we can use the BST property that root is always smaller than it's childs and left child will always be smaller than right child. Need to implement that instead of the Binary Tree solution.
public class Codec
{
    private readonly string NULL_REPRESENTATION = "n";
    private int index = 0;
    private List<string> nodeValues = [];

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        DFSPreorderTraversal(root);
        string serializedTree = string.Join(",", nodeValues);
        return serializedTree;
    }

    private void DFSPreorderTraversal(TreeNode node)
    {
        if (node == null)
        {
            nodeValues.Add(NULL_REPRESENTATION);
            return;
        }

        nodeValues.Add(node.val.ToString());
        DFSPreorderTraversal(node.left);
        DFSPreorderTraversal(node.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        nodeValues = data.Split(',').ToList();
        TreeNode node = DFSPreorderDeserializeTree();
        return node;
    }

    private TreeNode DFSPreorderDeserializeTree()
    {
        if (nodeValues.Count == 0 || nodeValues[index] == NULL_REPRESENTATION)
        {
            index++;
            return null;
        }

        TreeNode node = new(int.Parse(nodeValues[index]));
        index++;

        node.left = DFSPreorderDeserializeTree();
        node.right = DFSPreorderDeserializeTree();
        return node;
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