var l13 = new ListNode(5);
var l12 = new ListNode(3, l13);
var list1 = new ListNode(1, l12);

var l23 = new ListNode(6);
var l22 = new ListNode(4, l23);
var list2 = new ListNode(2, l22);

Console.WriteLine(new Solution().MergeTwoLists(list1, list2));
Console.ReadLine();

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode mergedHead = new();
        ListNode dummy = mergedHead;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                dummy.next = list1;
                list1 = list1.next;
            }
            else
            {
                dummy.next = list2;
                list2 = list2.next;
            }

            dummy = dummy.next;
        }

        if (list1 != null)
            dummy.next = list1;
        else if (list2 != null)
            dummy.next = list2;

        return mergedHead.next;
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