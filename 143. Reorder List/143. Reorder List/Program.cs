//var l5 = new ListNode(5);
var l4 = new ListNode(4);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

new Solution().ReorderList(head);
Console.ReadLine();

public class Solution
{
    public void ReorderList(ListNode head)
    {
        ListNode slow = head, fast = head, previous = null;

        //Slow moves one step while fast moves two steps. By the time fast reaches the end (for even length, fast will be null. But for odd length, fast.next will be null), slow will be at the mid node
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        //Cutting off the link after the mid node to create two separate lists
        var nextOfMid = slow.next;
        slow.next = null;
        slow = nextOfMid;

        while (slow != null)
        {
            var next = slow.next;
            slow.next = previous;
            previous = slow;
            slow = next;
        }

        slow = head;

        while (slow != null && previous != null)
        {
            var nextOfSlow = slow.next;
            var nextOfPrevious = previous.next;
            previous.next = nextOfSlow;
            slow.next = previous;
            previous = nextOfPrevious;
            slow = nextOfSlow;
        }
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