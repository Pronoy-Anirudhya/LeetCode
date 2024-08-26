Console.WriteLine(new Solution().EvalRPN(["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]));
Console.ReadLine();

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var tokenStack = new Stack<int>();

        for (int i = 0; i < tokens.Length; i++)
        {
            var token = tokens[i];

            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                var secondNumber = tokenStack.Pop();
                var firstNumber = tokenStack.Pop();
                tokenStack.Push(EvaluateExpression(firstNumber, secondNumber, token));
            }
            else
                tokenStack.Push(int.Parse(token));
        }

        return tokenStack.Pop();
    }

    private static int EvaluateExpression(int num1, int num2, string operatorToken)
    {
        return operatorToken switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => num1 / num2,
            _ => 0,
        };
    }
}