var l10 = new ListNode(10);
var l9 = new ListNode(9, l10);
var l8 = new ListNode(8, l9);
var l7 = new ListNode(7, l8);
var l6 = new ListNode(6, l7);
var l5 = new ListNode(5, l6);
var l4 = new ListNode(4, l5);
var l3 = new ListNode(3, l4);
var l2 = new ListNode(2, l3);
var head = new ListNode(1, l2);

Console.WriteLine(new Solution().SplitListToParts(head, 3));
Console.ReadLine();

public class Solution
{
    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        var splitNodes = new ListNode[k];
        var currentNode = head;
        var totalNodeCount = 0;

        while (currentNode != null)
        {
            currentNode = currentNode.next;
            totalNodeCount++;
        }

        currentNode = head;

        int splitSize = totalNodeCount / k;
        int remainigNodesAfterSplitting = totalNodeCount % k;

        for (int index = 0; index < k; index++)
        {
            var currentSplitSize = splitSize;

            if (remainigNodesAfterSplitting > 0)
            {
                currentSplitSize += 1;
                remainigNodesAfterSplitting--;
            }

            ListNode ithHead = new(); //This is the head of the i-th node that will have the reference of i-th traversal node
            ListNode ithTraversalNode = ithHead; //This will be used to traverse and prepare the i-th node

            for (int ithNodeIndex = 0; ithNodeIndex < currentSplitSize; ithNodeIndex++)
            {
                ithTraversalNode.next = new ListNode(currentNode.val);
                ithTraversalNode = ithTraversalNode.next;
                currentNode = currentNode.next;
            }

            splitNodes[index] = ithHead.next;
        }

        return splitNodes;
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
