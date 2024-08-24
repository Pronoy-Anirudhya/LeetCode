var l1 = new ListNode(1);
var l2 = new ListNode(3);
var l3 = new ListNode(4);
var l4 = new ListNode(7);
var l5 = new ListNode(1);
var l6 = new ListNode(2);
var l7 = new ListNode(6);

//l1.next = l2;
l2.next = l3;
l3.next = l4;
l4.next = l5;
l5.next = l6;
l6.next = l7;

Console.WriteLine(new Solution().DeleteMiddle(l1));
Console.ReadLine();

public class Solution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        if (head == null)
            return head;

        var crawl = head;
        var listLength = 0;

        while (crawl != null)
        {
            crawl = crawl.next;
            listLength++;
        }

        var midIndex = listLength / 2;

        if (midIndex <= 0)
            return null;

        midIndex -= 1;
        crawl = head;

        while (midIndex > 0)
        {
            crawl = crawl.next;
            midIndex--;
        }

        crawl.next = crawl.next.next;
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