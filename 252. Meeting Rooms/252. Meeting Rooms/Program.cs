var interval1 = new Interval(9, 15);
var interval2 = new Interval(5, 8);
//var interval3 = new Interval(15, 20);

var intervals = new Interval[] { interval1, interval2 };

Console.WriteLine(new Solution().CanAttendMeetings(intervals.ToList()));
Console.ReadLine();

public class Solution
{
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort(Comparer<Interval>.Create((a, b) => a.end.CompareTo(b.end)));
        int previousEnd = int.MinValue;

        foreach (Interval interval in intervals)
        {
            if (previousEnd > interval.start)
                return false;

            previousEnd = interval.end;
        }

        return true;
    }
}

public class Interval
{
    public int start, end;

    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}