LRUCache lRUCache = new(2);
lRUCache.Get(2);
lRUCache.Put(2, 6);
lRUCache.Get(1);
lRUCache.Put(1, 5);
lRUCache.Put(1, 2);
lRUCache.Get(1);
lRUCache.Get(2);
Console.ReadLine();

public class LRUCache
{
    private readonly int Capacity;
    private readonly Node Left, Right; //Left.next will have the LRU KEY whereas Right.Previous will have the Most Recently Used KEY
    private readonly Dictionary<int, Node> lruCache;

    public LRUCache(int capacity)
    {
        Capacity = capacity;
        lruCache = [];
        lruCache.EnsureCapacity(capacity);//It makes the performance optimal by allocating the Dictionary capacity as stated during runtime so that it doesn't have to resize up to capacity
        Left = new(0, 0);
        Right = new(0, 0);
        Left.Next = Right;
        Right.Previous = Left;
    }

    public int Get(int key)
    {
        if (lruCache.TryGetValue(key, out var node))
        {
            Remove(node);
            InsertAtLast(node, true);
            return node.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        //When we have reached the capacity and the new pair to be added does not exist in the Dictionary, it means we have to add a new entry. For that, first we have to remove the LRU which is Left.next
        if (lruCache.Count == Capacity && !lruCache.ContainsKey(key))
            Remove(Left.Next);

        if (lruCache.TryGetValue(key, out var node))
        {
            Remove(node);
            node.Value = value;
            InsertAtLast(node, true);
        }
        else
        {
            Node newNode = new(key, value);
            InsertAtLast(newNode, false);
        }
    }

    private void Remove(Node node)
    {
        Node previous = node.Previous;
        Node next = node.Next;
        previous.Next = next;
        next.Previous = previous;
        lruCache.Remove(node.Key);
    }

    private void InsertAtLast(Node node, bool isExistingKey)
    {
        Node previous = Right.Previous;
        previous.Next = node;
        node.Previous = previous;
        node.Next = Right;
        Right.Previous = node;

        if (isExistingKey)
            lruCache[node.Key] = node;
        else
            lruCache.Add(node.Key, node);

    }
}

public class Node(int key, int value)
{
    public int Key { get; set; } = key;
    public int Value { get; set; } = value;
    public Node Next { get; set; } = null;
    public Node Previous { get; set; } = null;
}