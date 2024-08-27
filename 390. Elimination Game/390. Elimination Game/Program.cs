Console.WriteLine(new Solution().LastRemaining(12));
Console.ReadLine();

public class Solution
{
    public int LastRemaining(int n)
    {
        bool shouldTraverseLeft = true;
        int numberRemovalCount = 0;
        int index = 0;
        Dictionary<int,int> traversalMap = new Dictionary<int,int>();

        for (int i = 0; i < n; i++)
            traversalMap[i] = 0;

        while (true)
        {
            if (numberRemovalCount == (n - 1))
                return index++;

            if (shouldTraverseLeft && index < n)
            {
                while (traversalMap[index] == 1)
                    index++;

                traversalMap[index] = 1;
                index += 2;
            }
            else if (!shouldTraverseLeft && index >= 0)
            {
                while (traversalMap[index] == 1)
                    index--;

                traversalMap[index] = 1;
                index -= 2;
            }

            if (index >= n)
            {
                shouldTraverseLeft = false;
                index = n - 1;

                while (traversalMap[index] == 1)
                    index--;
            }
            else if (index < 0)
            {
                shouldTraverseLeft = true;
                index = 0;

                while (traversalMap[index] == 1)
                    index++;
            }

            numberRemovalCount++;
        }
    }
}