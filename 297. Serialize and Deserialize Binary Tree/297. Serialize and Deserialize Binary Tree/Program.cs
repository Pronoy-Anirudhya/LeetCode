var l1 = new TreeNode(1);
var l2 = new TreeNode(2);
var l3 = new TreeNode(3);
var l4 = new TreeNode(4);
var l5 = new TreeNode(5);

l1.left = l2;
l1.right = l3;
l3.left = l4;
l3.right = l5;

var data = new Codec().serialize(l1);
Console.WriteLine(data);
Console.WriteLine(new Codec().deserialize(data));
Console.ReadLine();

public class Codec
{
    private readonly string NULL_REPRESENTATION = "n";
    private List<string> nodeValues = [];
    private int index = 0;

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        DFSPreorderTraversal(root);
        string serializedTreeNodes = string.Join(",", nodeValues);
        return serializedTreeNodes;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        nodeValues = data.Split(",").ToList();
        return DeserializedFromPreorderTreeString();
    }

    private void DFSPreorderTraversal(TreeNode node)
    {
        //For null child nodes, we will add "n" which will make the desrialization process easier since when we get an "n", we would know that the subtree is completed and we can just return during deserialization process
        if (node == null)
        {
            nodeValues.Add(NULL_REPRESENTATION);
            return;
        }

        nodeValues.Add(node.val.ToString());
        DFSPreorderTraversal(node.left);
        DFSPreorderTraversal(node.right);
    }

    private TreeNode DeserializedFromPreorderTreeString()
    {
        if (index >= nodeValues.Count || nodeValues[index] == NULL_REPRESENTATION)
        {
            index++;
            return null;
        }

        TreeNode node = new(int.Parse(nodeValues[index]));
        index++;

        node.left = DeserializedFromPreorderTreeString();
        node.right = DeserializedFromPreorderTreeString();

        return node;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x){
        val = x;
    }
}