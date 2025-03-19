Console.WriteLine(new Solution().MinOperations([0, 1, 1, 1, 0, 0]));
Console.ReadLine();

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int minOperationCount = 0, numberOfOnes = 0;

        for (int index = 0; index < nums.Length; index++)
            if (nums[index] == 1)
                numberOfOnes++;

        for (int index = 0; index < nums.Length; index++)
        {
            //Already 1, no need for any operation
            if (nums[index] == 1)
                continue;

            //For a valid operation to happen, we need three consecutive indexes to flip. That's why we are checking whether from the current index, do we have three valid indexes that don't go out of the bound. If it does go out of the bound, we will not perform the operation.
            if (index + 2 >= nums.Length)
                continue;

            minOperationCount++;
            numberOfOnes++;
            nums[index] = 1;

            for (int innerIndex = index + 1; innerIndex <= index + 2 && innerIndex < nums.Length; innerIndex++)
            {
                if (nums[innerIndex] == 0)
                {
                    nums[innerIndex] = 1;
                    numberOfOnes++;
                }
                else
                {
                    nums[innerIndex] = 0;
                    numberOfOnes--;
                }
            }
        }

        //If all the elements in the array are 1, then numberOfOnes will be equal to the array's length. If not, we return -1 since it's not possible to make all the elements in the array 1.
        return numberOfOnes == nums.Length ? minOperationCount : -1;
    }
}