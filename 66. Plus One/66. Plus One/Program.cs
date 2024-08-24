Console.WriteLine(new Solution().PlusOne(new int[] { 9, 9, 9 }));

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        int carry = 0;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            var plusOne = digits[i] + carry + (i == digits.Length - 1 ? 1 : 0);
            var plusOneResult = plusOne % 10;
            carry = plusOne / 10;
            digits[i] = plusOneResult;
        }

        if (carry == 1)
        {
            var result = new int[digits.Length + 1];
            result[0] = carry;
            digits.CopyTo(result, 1);
            return result;
        }

        return digits;
    }
}