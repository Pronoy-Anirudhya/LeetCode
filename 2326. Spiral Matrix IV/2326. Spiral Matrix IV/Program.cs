var l13 = new ListNode(0);
var l12 = new ListNode(5, l13);
var l11 = new ListNode(5, l12);
var l10 = new ListNode(2, l11);
var l9 = new ListNode(4, l10);
var l8 = new ListNode(9, l9);
var l7 = new ListNode(7, l8);
var l6 = new ListNode(1, l7);
var l5 = new ListNode(8, l6);
var l4 = new ListNode(6, l5);
var l3 = new ListNode(2, l4);
var l2 = new ListNode(0, l3);
var head = new ListNode(3, l2);

Console.WriteLine(new Solution().SpiralMatrix(3, 5, head));
Console.ReadLine();

public enum Direction
{
    RIGHT,
    DOWN,
    LEFT,
    UP
}

public class Solution
{
    private const int DEFAULT_MATRIX_VALUE = -1;
    private Direction direction = Direction.RIGHT;

    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        var spiralMatrix = new int[m][];

        for (int i = 0; i < spiralMatrix.Length; i++)
        {
            spiralMatrix[i] = new int[n];

            for (int j = 0; j < n; j++)
                spiralMatrix[i][j] = DEFAULT_MATRIX_VALUE;
        }

        int row = 0, col = 0;

        while (head != null)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    if (col < n && spiralMatrix[row][col] == DEFAULT_MATRIX_VALUE)
                    {
                        spiralMatrix[row][col] = head.val;
                        head = head.next;
                        col++;
                    }
                    else
                    {
                        row++;
                        col--;
                        direction = Direction.DOWN;
                    }
                    break;
                case Direction.DOWN:
                    if (row < m && spiralMatrix[row][col] == DEFAULT_MATRIX_VALUE)
                    {
                        spiralMatrix[row][col] = head.val;
                        head = head.next;
                        row++;
                    }
                    else
                    {
                        col--;
                        row--;
                        direction = Direction.LEFT;
                    }
                    break;
                case Direction.LEFT:
                    if (col >= 0 && spiralMatrix[row][col] == DEFAULT_MATRIX_VALUE)
                    {
                        spiralMatrix[row][col] = head.val;
                        head = head.next;
                        col--;
                    }
                    else
                    {
                        row--;
                        col++;
                        direction = Direction.UP;
                    }
                    break;
                case Direction.UP:
                    if (row >= 0 && spiralMatrix[row][col] == DEFAULT_MATRIX_VALUE)
                    {
                        spiralMatrix[row][col] = head.val;
                        head = head.next;
                        row--;
                    }
                    else
                    {
                        col++;
                        row++;
                        direction = Direction.RIGHT;
                    }
                    break;
                default:
                    break;
            }
        }

        return spiralMatrix;
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