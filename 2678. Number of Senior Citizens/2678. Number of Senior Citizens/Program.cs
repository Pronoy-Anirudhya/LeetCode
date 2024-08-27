Console.WriteLine(new Solution().CountSeniors(["7868190130M7522", "5303914400F9211", "9273338290F4010"]));
Console.ReadLine();

public class Solution
{
    public int CountSeniors(string[] details)
    {
        var seniorCount = 0;

        foreach (var passenger in details)
        {
            var age = int.Parse(passenger[11].ToString()) * 10 + int.Parse(passenger[12].ToString());

            if (age > 60)
                seniorCount++;
        }

        return seniorCount;
    }
}