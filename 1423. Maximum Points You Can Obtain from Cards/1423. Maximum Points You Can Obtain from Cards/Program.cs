var cardPoints = new int[] { 11, 49, 100, 20, 86, 29, 72 };
var result = new Solution().MaxScore(cardPoints, 4);
Console.WriteLine("Result: " + result);
Console.ReadLine();

public class Solution
{
    public int MaxScore(int[] cardPoints, int k)
    {
        if (cardPoints.Length == k)
            return cardPoints.Sum();

        var counter = 0;
        var sum = 0;
        var currentCardPoints = cardPoints;

        for (int i = 0; i < cardPoints.Length; i++)
        {
            var cardPointToBeAdded = 0;
            var currentIterationFirstNumber = currentCardPoints.First();
            var currentIterationLastNumber = currentCardPoints.Last();

            if (currentIterationFirstNumber > currentIterationLastNumber)
            {
                cardPointToBeAdded = currentIterationFirstNumber;
                currentCardPoints = currentCardPoints.Skip(1).ToArray();
            }
            else
            {
                cardPointToBeAdded = currentIterationLastNumber;
                currentCardPoints = currentCardPoints.SkipLast(1).ToArray();
            }

            sum += cardPointToBeAdded;
            counter++;

            if (counter == k)
                break;
        }

        return sum;
    }
}