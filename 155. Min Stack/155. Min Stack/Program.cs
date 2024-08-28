var minStack = new MinStack();
minStack.Push(-2);
minStack.Push(0);
minStack.Push(-3);
Console.WriteLine("Top: " + minStack.Top());
Console.WriteLine("Min: " + minStack.GetMin());
minStack.Pop();
Console.WriteLine("Top: " + minStack.Top());
Console.WriteLine("Min: " + minStack.GetMin());
Console.ReadLine();

public class MinStack
{
    private readonly Stack<int> Stack;
    private readonly Stack<int> MinimumValueStack; //For each index of main stack, it will hold the minimum value as of that index

    public MinStack()
    {
        Stack = new();
        MinimumValueStack = new();
    }

    public void Push(int val)
    {
        Stack.Push(val);

        var currentMinimumValue = MinimumValueStack.Count == 0 ? val : Math.Min(val, MinimumValueStack.Peek());
        MinimumValueStack.Push(currentMinimumValue);
    }

    public void Pop()
    {
        Stack.Pop();
        MinimumValueStack.Pop();
    }

    public int Top()
    {
        return Stack.Peek();
    }

    public int GetMin()
    {
        return MinimumValueStack.Peek();
    }
}