//[[1, 4, 5], [1, 3, 4], [2, 6]]
var l13 = new ListNode(5);
var l12 = new ListNode(4, l13);
var l11 = new ListNode(1, l12);

var l23 = new ListNode(4);
var l22 = new ListNode(3, l23);
var l21 = new ListNode(1, l22);

var l32 = new ListNode(6);
var l31 = new ListNode(2, l32);

Console.WriteLine(new Solution().MergeKLists([l11, l21, l31]));
Console.ReadLine();

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
            return null;

        if (lists.Length == 1)
            return lists[0];

        while (lists.Length > 1)
        {
            List<ListNode> nodes = [];

            //We are doing MERGE SORT here, that's why incrementing index two steps. For odd cases, last segment of the merge sort will have list2 with out of bound index, for which we have put in a check there.
            for (int index = 0; index < lists.Length; index += 2)
            {
                ListNode? list1 = lists[index];
                ListNode? list2 = (index + 1) < lists.Length ? lists[index + 1] : null;
                nodes.Add(MergeLists(list1, list2));
            }

            lists = nodes.ToArray();
        }

        return lists[0];
    }

    private static ListNode MergeLists(ListNode? list1, ListNode? list2)
    {
        ListNode mergedList = new();
        ListNode current = mergedList;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        if (list1 != null)
            current.next = list1;
        else if (list2 != null)
            current.next = list2;

        return mergedList.next;
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