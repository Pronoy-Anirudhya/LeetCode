//var l6 = new ListNode(6);
var l5 = new ListNode(5);
var l4 = new ListNode(4, l5);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

Console.WriteLine(new Solution().ReverseKGroup(head, 3));
Console.ReadLine();

public class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k == 1)
            return head;

        ListNode reversedHead = new(), current = head, previous, previousReversedHead, previousReveresedTail, currentReversedHead, currentReveresedTail;
        previous = previousReversedHead = previousReveresedTail = currentReversedHead = currentReveresedTail = null;
        int listLength = 0;

        while (current != null)
        {
            current = current.next;
            listLength++;
        }

        int kGroupCount = listLength / k;
        current = head;

        for (int count = 0; count < kGroupCount; count++)
        {
            currentReveresedTail = current;

            for (int nodeCount = k; nodeCount > 0; nodeCount--)
            {
                ListNode currentNext = current.next;
                current.next = previous;
                previous = current;
                current = currentNext;
            }

            currentReversedHead = previous;
            previous = null;

            if (previousReveresedTail != null)
                previousReveresedTail.next = currentReversedHead;

            previousReversedHead = currentReversedHead;
            previousReveresedTail = currentReveresedTail;

            if (count == 0)
                reversedHead.next = currentReversedHead;
        }

        if (listLength % k != 0)
            previousReveresedTail.next = current;

        return reversedHead.next;
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