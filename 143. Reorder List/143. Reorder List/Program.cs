var l5 = new ListNode(5);
var l4 = new ListNode(4, l5);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

new Solution().ReorderList(head);
Console.ReadLine();

public class Solution
{
    public void ReorderList(ListNode head)
    {
        int listLength = 0; 
        ListNode previous = null, current = head, dummy = new();

        while (current != null)
        {
            current = current.next;
            listLength++;
        }

        current = head;
        int index = 0;

        while (current != null)
        {
            bool isOverMidwayOfList = listLength % 2 == 0 ? index >= (listLength / 2) : index > (listLength / 2);

            if (isOverMidwayOfList)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            else if (listLength % 2 == 0 ? index == (listLength / 2) - 1 : index == (listLength / 2))
            {
                var next = current.next;
                current.next = null;
                current = next;
            }
            else
                current = current.next;

            index++;
        }

        current = head;

        while (current != null && previous != null)
        {
            var currentNext = current.next;
            var previousNext = previous.next;
            previous.next = currentNext;
            current.next = previous;
            current = currentNext;
            previous = previousNext;
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