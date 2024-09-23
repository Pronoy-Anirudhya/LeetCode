var l5 = new ListNode(5);
var l4 = new ListNode(4, l5);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

Console.WriteLine(new Solution().RemoveNthFromEnd(head, 2));
Console.ReadLine();

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode current, slow, fast;
        current = slow = fast = head;
        int index = 0;

        for (; index < n; index++)
            fast = fast.next;

        //When fast is NULL after moving fast for n-times, that means n == the length of the lits. In this edge case, we just shift the head to the next and return the answer.
        if (fast == null)
            return head.next;

        //After exiting while loop, slow will be just before the n-th node from the end. So we will assign slow.next by skipping 1 step so that the n-th node gets deleted.
        while (fast != null && fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return head;
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