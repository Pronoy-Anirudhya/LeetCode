using System.Text;

Console.WriteLine(new Solution().PushDominoes(".L.R."));
Console.ReadLine();

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        StringBuilder result = new StringBuilder(dominoes);
        int left = 0;

        for (int right = 0; right < dominoes.Length; right++)
        {
            char leftDomino = dominoes[left], rightDomino = dominoes[right];

            //Nothing to do, we will stop only if the domino os L or R
            if (rightDomino == '.')
                continue;

            //If both the dominoes have been pushed to the same direction (e.g. L..L/R..R), then there's no conflict and all the dominoes in between will have the same direction. Same for when left domino is . and the right domino has been pushed to the left. Then all the dominoes in the right will be pushed to the left as well. In both case, all the dominoes can be said to have the same push as right domino.
            if (leftDomino == rightDomino || (leftDomino == '.' && rightDomino == 'L'))
            {
                while (left < right)
                {
                    result[left] = rightDomino;
                    left++;
                }
            }
            //When boh the dominoes have been pushed to the opposite direction or left domino is . and right one has been pushed to the right direction, nothing will happen to the dominoes to left of the right domino.
            else if ((leftDomino == '.' && rightDomino == 'R') || (leftDomino == 'L' && rightDomino == 'R'))
            {
                left = right;
            }
            //Here, a conflicting push has been given to left and right dominoes where left is falling to the right and right is falling to the left. So from left, every dominio will get pushed to the left domino's direction e.g. right and from right, very domino will get pushed to the right domino's direction e.g. left. But the if there's a middle domino in between left and right, it will stay as-is because of the opposite push from both direction, that's why the while loop will break if left == right.
            else if (leftDomino == 'R' && rightDomino == 'L')
            {
                int tempLeft = left, tempRight = right;
                
                while (++tempLeft < --tempRight)
                {
                    result[tempLeft] = leftDomino;
                    result[tempRight] = rightDomino;
                }

                left = right;
            }
        }

        //When all the right dominoes have been processed but the left is still not at the end (e.g. left < dominoes.length - 1) and the left domino was pushed to the right, all the subsequent dominoes to the right of the left domino will also be pushed to the right direction.
        if (left < dominoes.Length - 1 && dominoes[left] == 'R')
        {
            while (left < dominoes.Length)
                result[left++] = 'R';
        }

        return result.ToString();
    }
}