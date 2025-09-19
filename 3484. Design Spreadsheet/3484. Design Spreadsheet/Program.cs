Console.WriteLine(new Spreadsheet(2));
Console.ReadLine();

public class Spreadsheet
{
    private readonly Dictionary<string, int> sheet;

    public Spreadsheet(int rows)
    {
        sheet = [];
    }

    public void SetCell(string cell, int value)
    {
        sheet[cell] = value;
    }

    public void ResetCell(string cell)
    {
        sheet[cell] = 0;
    }

    // Formula is always in the form of "=X+Y" where X and Y can be either a cell or a number. E.g. "=A1+5", "=3+B2", "=A1+B2", "=4+5".
    public int GetValue(string formula)
    {
        var parsedFormula = formula.Split('+');
        int x = GetNumber(parsedFormula[0].Substring(1)), y = GetNumber(parsedFormula[1]); // Remove the '=' from the first part of the formula (x). The second part (y) does not have '=' so we don't need to remove anything.
        return x + y;
    }

    // Helper method to get the number from either a cell or a number string. If it's a cell, look up its value in the sheet dictionary. If it's a number, parse it to an integer. If the cell does not exist in the dictionary, return 0.
    private int GetNumber(string cellOrNumber)
    {
        // Check if the first character is a number (0-9). If it is, we can assume the whole string is a number. If it's not, we can assume it's a cell (e.g. "A1", "B2", etc.).
        bool isNumber = char.IsNumber(cellOrNumber[0]);

        // If it's a number, parse it to an integer and return it.
        if (isNumber)
            return int.Parse(cellOrNumber);

        // If it's a cell, look up its value in the sheet dictionary. If the cell does not exist in the dictionary, return 0.
        if (sheet.TryGetValue(cellOrNumber, out int value))
            return value;

        return 0;
    }
}