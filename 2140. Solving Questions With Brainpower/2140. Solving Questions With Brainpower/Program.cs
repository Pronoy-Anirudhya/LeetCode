Console.WriteLine(new Solution().MostPoints([[21, 5], [92, 3], [74, 2], [39, 4], [58, 2], [5, 5], [49, 4], [65, 3]]));
Console.ReadLine();

public class Solution
{
    public long MostPoints(int[][] questions)
    {
        long[] dpPoint = new long[questions.Length];
        long maxPointFromTheEnd = long.MinValue;

        /*
        Intuition: Classic take it or skip it problem. So we will gain question[index][0] points by answering questions but that means we have to skip the next question[index][1] number of questions. After skipping, not necessariliy we have to answer the immediate solvable question. Main observation: So when we come to the next solvable question, we would want to maximize our point. So if solving the current question gives less point than any other questions after that, we would to answer that one instead of the current question. This observation leads to the DP solution where we would start from the end to see how much point we can gain by answering that question and then store the maximum between currentPoint and points gained by answering any questions after that. This way, our dpPoint[index] will always hold the maximum point we can gain from that specific index.
        */
        for (int index = questions.Length - 1; index >= 0; index--)
        {
            int currentPoint = questions[index][0], currentBrainPower = questions[index][1], nextQuestionIndex = index + currentBrainPower + 1;
            long nextQuestionPoint = nextQuestionIndex < questions.Length ? dpPoint[nextQuestionIndex] : 0; //If the index is out of bound, we gain 0 point. Otherwise get the maximum point from the dpPoint array.
            long pointBySolvingCurrentQuestion = currentPoint + nextQuestionPoint;

            maxPointFromTheEnd = Math.Max(maxPointFromTheEnd, pointBySolvingCurrentQuestion); //Always store the maximum point between current and any questions from the end.
            dpPoint[index] = maxPointFromTheEnd; //This ensures that the dpPoint will always have the maximum point at any specific index.
        }

        return dpPoint[0]; //dpPoint[0] will have the maximum point we can gain since we have started from the back and calculated the maximum point for each index.
    }
}