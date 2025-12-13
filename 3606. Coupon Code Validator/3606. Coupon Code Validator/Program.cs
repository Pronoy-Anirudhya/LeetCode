Console.WriteLine(new Solution().ValidateCoupons(["MI", "b_"], ["pharmacy", "pharmacy"], [true, true]));
Console.ReadLine();

public class Solution
{
    private static readonly string[] validBusinessline = ["electronics", "grocery", "pharmacy", "restaurant"];

    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        List<Coupon> coupons = [];

        for (int index = 0; index < code.Length; index++)
        {
            if (!isActive[index])
                continue;

            if (!IsValidBusinessline(businessLine[index]))
                continue;

            if (!IsValidCoupon(code[index]))
                continue;

            coupons.Add(new Coupon(code[index], businessLine[index]));
        }

        // Sort the valid coupons first by business line and then by coupon code in ascending order. StringComparer.Ordinal is used for case-sensitive sorting. It ensures that uppercase letters come before lowercase letters in the sorted order.
        List<string> sortedValidCoupons = coupons
            .OrderBy(coupon => coupon.BusinessLine)
            .ThenBy(coupon => coupon.Code, StringComparer.Ordinal)
            .Select(coupon => coupon.Code)
            .ToList();

        return sortedValidCoupons;
    }

    private static bool IsValidBusinessline(string businessLine)
    {
        return validBusinessline.Contains(businessLine);
    }

    private static bool IsValidCoupon(string coupon)
    {
        // Check for null or empty coupon code. Return false if it is.
        if (string.IsNullOrEmpty(coupon))
            return false;

        for (int index = 0; index < coupon.Length; index ++)
        {
            char currentCharacter = coupon[index];

            // A valid coupon code contains only alphanumeric characters and underscores.
            if (!char.IsLetter(currentCharacter) && !char.IsDigit(currentCharacter) && currentCharacter != '_')
                return false;
        }

        return true;
    }

    public record Coupon(string Code, string BusinessLine);
}