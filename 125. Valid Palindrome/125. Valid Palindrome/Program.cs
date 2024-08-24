Console.WriteLine(new Solution().IsPalindrome("A man, a plan, a canal: Panama"));
Console.ReadLine();

public class Solution
{
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        s = s.ToLower();
        var leftPointer = 0;
        var rightPointer = s.Length - 1;

        while (leftPointer <= rightPointer)
        {
            int asciiValueOfLeftCharacter = s[leftPointer];
            int asciiValueOfRightCharacter = s[rightPointer];

            if (IsValidPalindromeCharacter(asciiValueOfLeftCharacter) && IsValidPalindromeCharacter(asciiValueOfRightCharacter))
            {
                if (s[leftPointer] != s[rightPointer])
                    return false;

                leftPointer++;
                rightPointer--;
            }
            else
            {
                if (!IsValidPalindromeCharacter(asciiValueOfLeftCharacter))
                    leftPointer++;

                if (!IsValidPalindromeCharacter(asciiValueOfRightCharacter))
                    rightPointer--;
            }
        }

        return true;
    }

    public bool IsValidPalindromeCharacter(int asciiValue)
    {
        return (asciiValue >= 97 && asciiValue <= 122) || (asciiValue >=48 && asciiValue <= 57);
    }
}