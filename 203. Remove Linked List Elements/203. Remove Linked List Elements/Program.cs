var l1 = new ListNode(1);
var l2 = new ListNode(2);
var l3 = new ListNode(1);
var l4 = new ListNode(3);
var l5 = new ListNode(4);
var l6 = new ListNode(5);
var l7 = new ListNode(6);

l1.next = l2;
l2.next = l3;
//l3.next = l4;
//l4.next = l5;
//l5.next = l6;
//l6.next = l7;

Console.WriteLine(new Solution().RemoveElements(l1, 1));
Console.ReadLine();

public class Solution
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode previousNode = null;
        var crawl = head;

        while (crawl != null)
        {
            if (crawl.val == val)
            {
                if (previousNode != null)
                    previousNode.next = null;
                else
                    head = head.next; 

                crawl = crawl.next;
                continue;
            }

            if (previousNode != null)
                previousNode.next = crawl;

            previousNode = crawl;
            crawl = crawl.next;
        }

        return previousNode != null ? head : previousNode;
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