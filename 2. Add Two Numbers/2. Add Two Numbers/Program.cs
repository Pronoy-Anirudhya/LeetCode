// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//var l1 = new ListNode(2);
//var l1_1 = new ListNode(4);
//var l1_2 = new ListNode(3);
//l1.next = l1_1;
//l1_1.next = l1_2;

//var l2 = new ListNode(5);
//var l2_1 = new ListNode(6);
//var l2_2 = new ListNode(4);
//l2.next = l2_1;
//l2_1.next = l2_2;

var l1 = new ListNode(9);
var l1_1 = new ListNode(9);
var l1_2 = new ListNode(9);
l1.next = l1_1;
l1_1.next = l1_2;

var l2 = new ListNode(9);

new Solution().AddTwoNumbers(l1, l2);

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

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        var head = result;
        var carry = 0;

        while (l1 != null || l2 != null)
        {
            var l1Value = l1 != null ? l1.val : 0;
            var l2Value = l2 != null ? l2.val : 0;

            var sum = (carry + l1Value + l2Value) % 10;
            carry = (carry + l1Value + l2Value) / 10;
            l1 = l1?.next;
            l2 = l2?.next;

            result.next = new ListNode(sum);
            result = result.next;
        };

        if (carry == 1)
        {
            result.next = new ListNode(carry);
            result = result.next;
        }

        head = head.next;
        return head;
    }
}