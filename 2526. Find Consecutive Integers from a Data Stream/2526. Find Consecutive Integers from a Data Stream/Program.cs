Console.WriteLine("Hello, World!");
Console.ReadLine();

public class DataStream
{
    private int Value, K, Index, LastNonValueIndex;

    public DataStream(int value, int k)
    {
        Value = value;
        K = k;
        Index = 0;
        LastNonValueIndex = -1;
    }

    public bool Consec(int num)
    {
        Index += 1;

        if (num != Value)
            LastNonValueIndex = Index;

        int validStreamLength = LastNonValueIndex != -1 ? Index - LastNonValueIndex : Index;
        return validStreamLength >= K;
    }
}