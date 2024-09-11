var l4 = new ListNode(3);
var l3 = new ListNode(10, l4);
var l2 = new ListNode(6, l3);
var head = new ListNode(18, l2);

Console.WriteLine(new Solution().InsertGreatestCommonDivisors(head));
Console.ReadLine();

public class Solution
{
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var currentNode = head;

        while (currentNode != null && currentNode.next != null)
        {
            ListNode midGCDNode = new();
            var rightNode = currentNode.next;
            currentNode.next = midGCDNode;
            midGCDNode.next = rightNode;

            int maxValue = Math.Max(currentNode.val, rightNode.val);
            int minValue = Math.Min(currentNode.val, rightNode.val);

            if (maxValue % minValue == 0)
                midGCDNode.val = minValue;
            else
            {
                var currentGCD = minValue / 2;

                while (currentGCD > 0)
                {
                    if (maxValue % currentGCD == 0 && minValue % currentGCD == 0)
                    {
                        midGCDNode.val = currentGCD;
                        break;
                    }

                    currentGCD--;
                }
            }

            currentNode = rightNode;
        }

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