var l1 = new ListNode(1);
var l2 = new ListNode(2);
var l3 = new ListNode(2);
var l4 = new ListNode(1);

l1.next = l2;
l2.next = l3;
l3.next = l4;

Console.WriteLine(new Solution().IsPalindrome(l1));
Console.ReadLine();

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
    public bool IsPalindrome(ListNode head)
    {
        var stack = new Stack<int>();
        var current  = head;
        var length = 0;

        while (current != null)
        {
            stack.Push(current.val);
            current = current.next;
            length++;
        }

        var median = length / 2;
        var isEvenMedian = median % 2 == 0;
        current = head;

        while ((isEvenMedian && median > 0) || (!isEvenMedian && median >= 0))
        {
            var reversedDigit = stack.Pop();

            if (reversedDigit != current.val)
                return false;

            current = current.next;
            median--;
        }

        return true;
    }
}