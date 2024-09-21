var l5 = new ListNode(5);
var l4 = new ListNode(4, l5);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

Console.WriteLine(new Solution().ReverseList(head));
Console.ReadLine();

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previous = null;
        ListNode current = head;

        while (current != null)
        {
            var currentNext = current.next;
            current.next = previous;
            previous = current;
            current = currentNext;
        }

        return previous;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}