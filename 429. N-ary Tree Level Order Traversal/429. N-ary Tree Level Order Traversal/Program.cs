Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        List<IList<int>> levelOrderNodes = [];

        if (root == null)
            return levelOrderNodes;

        Queue<Node> bfsQueue = [];
        bfsQueue.Enqueue(root);

        while (bfsQueue.Count > 0)
        {
            int currentLevelNodeCount = bfsQueue.Count;
            List<int> currentLevelNodes = [];

            while (currentLevelNodeCount-- > 0)
            {
                Node node = bfsQueue.Dequeue();
                currentLevelNodes.Add(node.val);

                if (node.children != null && node.children.Count > 0)
                {
                    foreach (Node childNode in node.children)
                        bfsQueue.Enqueue(childNode);
                }
            }

            levelOrderNodes.Add(currentLevelNodes);
        }

        return levelOrderNodes;
    }
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}