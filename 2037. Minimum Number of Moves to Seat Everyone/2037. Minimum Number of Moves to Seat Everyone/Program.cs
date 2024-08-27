Console.WriteLine(new Solution().MinMovesToSeat([3, 1, 5], [2, 7, 4]));
Console.ReadLine();

public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        var moves = 0;

        Array.Sort(seats);
        Array.Sort(students);

        for (int i = 0; i < seats.Length; i++)
            moves += Math.Abs(seats[i] - students[i]);

        return moves;
    }
}