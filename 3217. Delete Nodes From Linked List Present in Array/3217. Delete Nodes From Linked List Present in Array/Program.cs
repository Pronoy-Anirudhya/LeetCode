var l6 = new ListNode(2);
var l5 = new ListNode(1, l6);
var l4 = new ListNode(2, l5);
var l3 = new ListNode(1, l4);
var l2 = new ListNode(2, l3);
var l1 = new ListNode(1, l2);

Console.WriteLine(new Solution().ModifiedList([1, 2], l1));
Console.ReadLine();

public class Solution
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        /*
         * The trick is, intorduce a new dummy Node (modifiedList) and set it's next to Head. Now for traversing, create another node (currentNode) and assign the dummy node to it. We will traverse through the currentNode and modify aloing the way. Since the assignment was pass by reference, so the actual dummy node will get updated too. At the end, we will just return the dummy node->next that was actually pointing the Head in the first place. 
        */
        var numSet = new HashSet<int>(nums);
        var modifiedList = new ListNode(0, head);
        var currentNode = modifiedList;

        while (currentNode.next != null)
        {
            if (numSet.Contains(currentNode.next.val))
                currentNode.next = currentNode.next.next;
            else
                currentNode = currentNode.next;
        }

        return modifiedList.next;
    }
}

public class ListNode(int val = 0, ListNode next = null)
{
    public int val = val;
    public ListNode next = next;
}