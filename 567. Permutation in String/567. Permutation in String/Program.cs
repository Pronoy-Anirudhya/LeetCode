Console.WriteLine(new Solution().CheckInclusion("ab", "lecabee"));
Console.ReadLine();

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        if (s1 == s2)
            return true;

        var s1Characters = s1.ToCharArray();
        var s2Characters = s2.ToCharArray();
        Dictionary<char, int> s1CharacterFrequencyMap = [];
        var left = 0;
        var currentOngoingSequenceLength = 0;
        bool isOngoingSequence = false;

        for (int index = 0; index < s1Characters.Length; index++)
        {
            var character = s1Characters[index];

            if (s1CharacterFrequencyMap.ContainsKey(character))
                s1CharacterFrequencyMap[character]++;
            else
                s1CharacterFrequencyMap[character] = 1;
        }

        for (int right = 0; right < s2Characters.Length; right++)
        {
            var currentRightCharacter = s2Characters[right];
            bool isinvalidInclusiveRightCharacter = !s1CharacterFrequencyMap.ContainsKey(currentRightCharacter);
            bool isInvalidInclusiveRightCharacterLength = !isinvalidInclusiveRightCharacter && s1CharacterFrequencyMap[currentRightCharacter] <= 0;

            if (isinvalidInclusiveRightCharacter || isInvalidInclusiveRightCharacterLength)
            {
                if (isInvalidInclusiveRightCharacterLength)
                    s1CharacterFrequencyMap[currentRightCharacter]--;

                while (left <= right)
                {
                    var currentLeftCharacter = s2Characters[left];

                    if (s1CharacterFrequencyMap.ContainsKey(currentLeftCharacter))
                        s1CharacterFrequencyMap[currentLeftCharacter]++;

                    left++;

                    if (isInvalidInclusiveRightCharacterLength && currentLeftCharacter == currentRightCharacter)
                        break;
                }

                isOngoingSequence = !isinvalidInclusiveRightCharacter;
            }
            else
            {
                if (!isOngoingSequence)
                    left = right;

                isOngoingSequence = true;
                s1CharacterFrequencyMap[currentRightCharacter]--;
                currentOngoingSequenceLength = right - left + 1;

                if (currentOngoingSequenceLength == s1.Length)
                    return true;
            }
        }

        return false;
    }
}