var l4 = new ListNode(4);
var l3 = new ListNode(3);
var l2 = new ListNode(2);
var head = new ListNode(1);
//l3.next = l4;
//l2.next = l3;
head.next = l2;
//l4.next = l2;

Console.WriteLine(new Solution().HasCycle(head));
Console.ReadLine();

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode slow, fast;
        slow = fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}