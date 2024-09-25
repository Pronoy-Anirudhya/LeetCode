var l1 = new ListNode(2);
var l1_1 = new ListNode(4);
var l1_2 = new ListNode(3);
l1.next = l1_1;
l1_1.next = l1_2;

var l2 = new ListNode(5);
var l2_1 = new ListNode(6);
var l2_2 = new ListNode(4);
l2.next = l2_1;
l2_1.next = l2_2;

//var l1 = new ListNode(9);
//var l1_1 = new ListNode(9);
//var l1_2 = new ListNode(9);
//l1.next = l1_1;
//l1_1.next = l1_2;

//var l2 = new ListNode(9);

Console.WriteLine(new Solution().AddTwoNumbers(l1, l2));
Console.ReadLine();

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode head = new(), currentNode = head;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int l1Value = l1 != null ? l1.val : 0;
            int l2Value = l2 != null ? l2.val : 0;

            int currentSum = l1Value + l2Value + carry;
            int numberToAddAfterCarry = currentSum % 10;
            carry = currentSum / 10;
            currentNode.next = new(numberToAddAfterCarry);
            currentNode = currentNode.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return head.next;
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