var students = new[] { 1, 1, 1, 0, 0, 1 };
var sandwiches = new[] { 1, 0, 0, 0, 1, 1 };
Console.WriteLine(new Solution().CountStudents(students, sandwiches));
Console.ReadLine();

public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var studentQueue = new Queue<int>();

        foreach (var student in students)
            studentQueue.Enqueue(student);

        var sandwichStack = new Stack<int>();

        for (int i = sandwiches.Length - 1; i >= 0; i--)
            sandwichStack.Push(sandwiches[i]);

        var studentCount = studentQueue.Count;

        while (studentQueue.Count > 0 && studentCount > 0)
        {
            var student = studentQueue.Dequeue();
            var sandwich = sandwichStack.Peek();

            if (student == sandwich)
            {
                sandwichStack.Pop();
                studentCount = studentQueue.Count;
            }
            else
            {
                studentQueue.Enqueue(student);
                studentCount--;
            }
        }

        return studentQueue.Count;
    }
}