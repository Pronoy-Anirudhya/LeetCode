Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int[] prefixArray = new int[A.Length];
        int prefixCount = 0;
        HashSet<int> arrayElementA = [];
        HashSet<int> arrayElementB = [];

        for (int index = 0; index < A.Length; index++)
        {
            int a = A[index], b = B[index];
            arrayElementA.Add(a);
            arrayElementB.Add(b);

            // If the current elements of both arrays are the same, we can directly increment the prefix count by 1. Because they are common in the prefix of both arrays.
            if (a == b)
                prefixCount += 1;
            else
            {
                // If the current elements of both arrays are different, we need to check if they are present in the prefix of the other array. If they are present, we can increment the prefix count by 1 for each element that is found in the other array's prefix.
                if (arrayElementA.Contains(b))
                    prefixCount += 1;

                if (arrayElementB.Contains(a))
                    prefixCount += 1;
            }

            prefixArray[index] = prefixCount;
        }

        return prefixArray;
    }
}