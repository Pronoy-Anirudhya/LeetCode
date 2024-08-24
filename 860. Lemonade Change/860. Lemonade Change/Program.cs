Console.WriteLine(new Solution().LemonadeChange([5, 5, 10, 20, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 5, 5, 20, 5, 20, 5]));
Console.ReadLine();

public class Solution
{
    public bool LemonadeChange(int[] bills)
    {
        var fiveDollarBillCount = 0;
        var tenDollarBillCount = 0;

        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5)
                fiveDollarBillCount++;
            else if (bills[i] == 10)
            {
                if (fiveDollarBillCount == 0)
                    return false;

                fiveDollarBillCount--;
                tenDollarBillCount++;
            }
            else if (bills[i] == 20)
            {
                if (tenDollarBillCount == 0)
                {
                    if (fiveDollarBillCount < 3)
                        return false;

                    fiveDollarBillCount -= 3;
                }
                else if (fiveDollarBillCount == 0)
                {
                    return false;
                }
                else
                {
                    fiveDollarBillCount--;
                    tenDollarBillCount--;
                }
            }
        }

        return true;
    }
}