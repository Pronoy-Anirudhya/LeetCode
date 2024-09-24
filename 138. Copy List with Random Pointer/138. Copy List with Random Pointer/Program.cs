var head = new Node(7);
var l2 = new Node(13);
var l3 = new Node(11);
var l4 = new Node(10);
var l5 = new Node(1);
head.next = l2;
l2.next = l3;
l3.next = l4;
l4.next = l5;
head.random = null;
l2.random = head;
l3.random = l5;
l4.random = l3;
l5.random = head;

Console.WriteLine(new Solution().CopyRandomList(head));
Console.ReadLine();

public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head == null)
            return null;

        Node current = head;
        Dictionary<Node, Node> oldNodeNewNodeMap = [];

        while (current != null)
        {
            Node copy = new(current.val);
            oldNodeNewNodeMap.Add(current, copy);
            current = current.next;
        }

        current = head;

        while (current != null)
        {
            Node copy = oldNodeNewNodeMap[current];
            copy.next = current.next != null ? oldNodeNewNodeMap[current.next] : null;
            copy.random = current.random != null ? oldNodeNewNodeMap[current.random] : null;
            current = current.next;
        }

        return oldNodeNewNodeMap[head];
    }
}

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}