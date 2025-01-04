var n1 = new Node(1);
var n2 = new Node(2);
var n3 = new Node(3);
var n4 = new Node(4);

n1.neighbors.Add(n2);
n1.neighbors.Add(n4);
n2.neighbors.Add(n1);
n2.neighbors.Add(n3);
n3.neighbors.Add(n4);
n3.neighbors.Add(n2);
n4.neighbors.Add(n1);
n4.neighbors.Add(n3);

Console.WriteLine(new Solution().CloneGraph(n1));
Console.ReadLine();

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        Dictionary<int, Node> sourceToCloneNodeMap = []; //When cloning the source node, we will keep the reference against the sourve val of the cloned Node so that we don recreate the same node again.
        return CloneGraph(node, sourceToCloneNodeMap);
    }

    private Node CloneGraph(Node source, Dictionary<int, Node> sourceToCloneNodeMap)
    {
        //If there already exist a cloned node for this value, just return it.
        if (sourceToCloneNodeMap.TryGetValue(source.val, out Node clone))
            return clone;

        clone = new(source.val);
        sourceToCloneNodeMap[source.val] = clone;

        //Base case. If no neighbors are there, no need to continue.
        if (source.neighbors.Count == 0)
            return clone;

        foreach (Node edge in source.neighbors)
            clone.neighbors.Add(CloneGraph(edge, sourceToCloneNodeMap)); //Recursively add the source neighbors into the cloned node.

        return clone;
    }
}

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}